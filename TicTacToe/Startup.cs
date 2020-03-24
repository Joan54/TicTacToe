namespace TicTacToe
{
    using Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Services;

    public class Startup
    {
        #region Public methods and operators

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
            }

            app.UseStaticFiles();
            app.UseCommunicationMiddleware();
            app.UseRouting();

            app.UseEndpoints( endpoints =>
                              {
                                  endpoints.MapControllerRoute(
                                                               name: "default",
                                                               pattern: "{controller=Home}/{action=Index}/{id?}" );
                                  endpoints.MapRazorPages();
                              } );
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton< IUserService, UserService >();
        }

        #endregion
    }
}
