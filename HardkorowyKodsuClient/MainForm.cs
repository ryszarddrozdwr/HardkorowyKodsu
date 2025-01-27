using BackendClient.Model;
using HardkorowyKodsuClient.Extensions;
using HardkorowyKodsuClient.Model;
using HardkorowyKodsuClient.Services;

namespace HardkorowyKodsuClient
{
    public partial class MainForm : Form
    {
        const string mainFormTitle = "HardkorowyKodsuClient";
        private readonly IBackendApi backendApi;

        public MainForm(IBackendApi backendApi)
        {
            InitializeComponent();
            this.backendApi = backendApi;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await GetTablesAndViewsAsync();
        }

        private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
            await GetTablesAndViewsAsync();
        }

        private async Task GetTablesAndViewsAsync()
        {
            Func<Task> getDatabaseName = async () =>
            {
                var databaseName = await backendApi.DatabaseName();
                this.Text = $"{mainFormTitle} - [{databaseName}]";
            };
            Action exceptionHandler = () =>
            {
                this.Text = $"{mainFormTitle} - Server not responding";
            };
            await getDatabaseName.HandleExceptionsAsync(exceptionHandler);

            Table[] tables = new Table[0];
            Table[] views = new Table[0];
            Func<Task> getTables = async () =>
            {
                var data = await backendApi.Tables();
                tables = data;
            };
            Func<Task> getViews = async () =>
            {
                var data = await backendApi.Views();
                views = data;
            };
            await getTables.HandleExceptionsAsync(exceptionHandler);
            await getViews.HandleExceptionsAsync(exceptionHandler);

            var total = tables.FromTables().AppendTable(views.FromViews());
            databaseBindingSource.DataSource = total;
            databaseGridView.DataSource = databaseBindingSource;
            databaseGridView.Columns["ID"].Visible = false;
            databaseGridView.Columns["Downloaded"].Visible = false;
        }

        private async void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
            await Task.Yield();
        }

        private void ClearAll()
        {
            this.Text = mainFormTitle;
            this.databaseBindingSource.Clear();
            this.columnsBindingSource.Clear();
            this.databaseGridView.DataSource = null;
            this.columnsGridView.DataSource = null;
        }

        private async void databaseGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = databaseGridView.CurrentRow;
            if(item != null)
            {
                var downloaded = (bool)item.Cells["Downloaded"].Value;
                if(downloaded)
                {
                    var columns = (ColumnItem[])(item?.Tag ?? new ColumnItem[0]);
                    columnsBindingSource.DataSource = columns;
                    columnsGridView.DataSource = columnsBindingSource;
                }
                else
                {
                    var type = (string)item.Cells["Type"].Value;
                    var id = (int)item.Cells["ID"].Value;
                    Func<Task> getColumns = async () =>
                    {
                        var data = type == "Table"
                        ? await backendApi.Table(id)
                        : await backendApi.View(id);
                        var columns = data.columns.FromColumns();
                        item.Cells["Downloaded"].Value = true;
                        item.Tag = columns;
                        columnsBindingSource.DataSource = columns;
                        columnsGridView.DataSource = columnsBindingSource;
                    };
                    Action<Refit.ApiException> exceptionHandler = (Refit.ApiException ex) =>
                    {
                        if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                            this.Text = $"{mainFormTitle} - ({id}) Not Found";
                        else
                            this.Text = $"{mainFormTitle} - Server not responding";
                    };
                    await getColumns.HandleExceptionsAsync<Refit.ApiException>(exceptionHandler);
                }
            }
        }
    }
}
