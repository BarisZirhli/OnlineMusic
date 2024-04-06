namespace OnlineMusicLibraryServer
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

            Thread server1 = new Thread(() =>
            {
                Application.Run(new Server1());
            });
            
            server1.Start();

            Thread server2 = new Thread(() =>
            {
                Application.Run(new Server2());
            });
            server2.Start();


        }
    }
}