namespace HardkorowyKodsuClient.Extensions
{
    public static class ActionExtension
    {
        public static bool HandleAExceptions(this Action action, Action exceptionHandler)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception)
            {
                exceptionHandler();
                return false;
            }
        }
        public static async Task<bool> HandleExceptionsAsync(this Func<Task> func, Action exceptionHandler)
        {
            try
            {
                await func();
                return true;
            }
            catch (Exception)
            {
                exceptionHandler();
                return false;
            }
        }
        public static bool HandleExceptions<EX>(this Action action, Action<EX> exceptionHandler)
            where EX : Exception
        {
            try
            {
                action();
                return true;
            }
            catch (EX ex)
            {
                exceptionHandler(ex);
                return false;
            }
        }
        public static async Task<bool> HandleExceptionsAsync<EX>(this Func<Task> func, Action<EX> exceptionHandler)
            where EX : Exception
        {
            try
            {
                await func();
                return true;
            }
            catch (EX ex)
            {
                exceptionHandler(ex);
                return false;
            }
        }
    }
}
