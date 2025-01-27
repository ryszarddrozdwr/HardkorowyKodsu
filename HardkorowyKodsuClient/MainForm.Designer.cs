namespace HardkorowyKodsuClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainStatusStrip = new StatusStrip();
            toolStripSplitButton = new ToolStripSplitButton();
            clearAllToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            databaseGridView = new DataGridView();
            columnsGridView = new DataGridView();
            databaseBindingSource = new BindingSource(components);
            columnsBindingSource = new BindingSource(components);
            mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)databaseGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)columnsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)columnsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // mainStatusStrip
            // 
            mainStatusStrip.ImageScalingSize = new Size(24, 24);
            mainStatusStrip.Items.AddRange(new ToolStripItem[] { toolStripSplitButton });
            mainStatusStrip.Location = new Point(0, 419);
            mainStatusStrip.Name = "mainStatusStrip";
            mainStatusStrip.Size = new Size(800, 31);
            mainStatusStrip.TabIndex = 0;
            // 
            // toolStripSplitButton
            // 
            toolStripSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton.DropDownItems.AddRange(new ToolStripItem[] { clearAllToolStripMenuItem, refreshToolStripMenuItem });
            toolStripSplitButton.Image = (Image)resources.GetObject("toolStripSplitButton.Image");
            toolStripSplitButton.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton.Name = "toolStripSplitButton";
            toolStripSplitButton.Size = new Size(45, 28);
            toolStripSplitButton.Text = "toolStripSplitButton";
            // 
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.Size = new Size(178, 34);
            clearAllToolStripMenuItem.Text = "Clear All";
            clearAllToolStripMenuItem.Click += clearAllToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(178, 34);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(databaseGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(columnsGridView);
            splitContainer1.Size = new Size(800, 419);
            splitContainer1.SplitterDistance = 394;
            splitContainer1.TabIndex = 1;
            // 
            // databaseGridView
            // 
            databaseGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            databaseGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            databaseGridView.Dock = DockStyle.Fill;
            databaseGridView.Location = new Point(0, 0);
            databaseGridView.Name = "databaseGridView";
            databaseGridView.RowHeadersWidth = 62;
            databaseGridView.Size = new Size(394, 419);
            databaseGridView.TabIndex = 0;
            databaseGridView.CellClick += databaseGridView_CellClick;
            // 
            // columnsGridView
            // 
            columnsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            columnsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            columnsGridView.Dock = DockStyle.Fill;
            columnsGridView.Enabled = false;
            columnsGridView.Location = new Point(0, 0);
            columnsGridView.Name = "columnsGridView";
            columnsGridView.RowHeadersWidth = 62;
            columnsGridView.Size = new Size(402, 419);
            columnsGridView.TabIndex = 0;
            // 
            // databaseBindingSource
            // 
            databaseBindingSource.DataSource = typeof(Model.TabularItem);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(mainStatusStrip);
            Name = "MainForm";
            Text = "HardkorowyKodsuClient";
            Load += MainForm_Load;
            mainStatusStrip.ResumeLayout(false);
            mainStatusStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)databaseGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)columnsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)columnsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip mainStatusStrip;
        private ToolStripSplitButton toolStripSplitButton;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem clearAllToolStripMenuItem;
        private SplitContainer splitContainer1;
        private DataGridView databaseGridView;
        private DataGridView columnsGridView;
        private BindingSource databaseBindingSource;
        private BindingSource columnsBindingSource;
    }
}
