namespace ANA_SUNUCU
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            SUNUCU.Setup_Server(2, 8585);
            SUNUCU.Start_Server();
            Application.Run(new Login());
        }
    }
}