namespace TicTacToe
{
    using Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Models;
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

            var options = new RewriteOptions().AddRewrite("NewUser", "UserRegistration/Index", false);
            app.UseRewriter( options );
            
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet( "CreateUser", context =>
                                               {
                                                   var firstName = context.Request.Query[ "firstName" ];
                                                   var lastName  = context.Request.Query[ "lastName" ];
                                                   var email     = context.Request.Query[ "email" ];
                                                   var password  = context.Request.Query[ "password" ];

                                                   var userService = context.RequestServices.GetService< IUserService >();

                                                   userService.RegisterUser( new UserModel
                                                                             {
                                                                                 FirstName = firstName,
                                                                                 LastName  = lastName,
                                                                                 Email     = email,
                                                                                 Password  = password
                                                                             } );

                                                   return context.Response.
                                                       WriteAsync( $"User {firstName} {lastName} has been successfully created." );
                                               }
                               );
            
            var newUserRoutes = routeBuilder.Build();
            
            app.UseRouter( newUserRoutes );

            app.UseCommunicationMiddleware();
            app.UseStatusCodePages( "text/plain", "HTTP Error - Status Code {0}" );

            app.UseRouting();

            app.UseEndpoints( endpoints =>
                              {
                                  endpoints.MapControllerRoute(
                                                               name: "default",
                                                               pattern: "{controller=Home}/{action=Index}/{id?}" );
                                  endpoints.MapRazorPages();
                                  endpoints.MapControllers();
                              } );
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton< IUserService, UserService >();
            services.AddRouting();
        }

        #endregion
    }
}
