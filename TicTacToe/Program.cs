namespace TicTacToe
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public static class Program
    {
        #region Public methods and operators

        private static IHostBuilder CreateHostBuilder( string[] args ) =>
            Host.CreateDefaultBuilder( args ).
                ConfigureWebHostDefaults( webBuilder =>
                                          {
                                              webBuilder.UseStartup< Startup >();

                                              webBuilder.CaptureStartupErrors( true );

                                              webBuilder.PreferHostingUrls( true );
                                              webBuilder.UseUrls( "http://localhost:5000" );
                                          } );

        public static void Main( string[] args )
        {
            CreateHostBuilder( args ).Build().Run();
        }

        #endregion
    }
}
