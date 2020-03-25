namespace TicTacToe.Middleware
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Services;

    public class CommunicationMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;
        private readonly IUserService    _userService;

        #endregion

        #region Constructors and Destructors

        public CommunicationMiddleware( RequestDelegate next, IUserService userService )
        {
            _next        = next;
            _userService = userService;
        }

        #endregion

        #region Public methods and operators

        public async Task Invoke( HttpContext context )
        {
            if ( context.Request.Path.Equals( "/CheckEmailConfirmationStatus" ) )
            {
                await ProcessEmailConfirmation( context );
            }
            else
            {
                await _next?.Invoke( context );
            }
        }

        #endregion

        #region Other methods

        private async Task ProcessEmailConfirmation( HttpContext context )
        {
            var email = context.Request.Query[ "email" ];

            var user = await _userService.GetUserByEmail( email );

            if ( string.IsNullOrEmpty( email ) )
            {
                await context.Response.WriteAsync( "BadRequest:Email is required" );
            }
            else if ( ( await _userService.GetUserByEmail( email ) ).IsEmailConfirmed )
            {
                await context.Response.WriteAsync( "OK" );
            }
            else
            {
                await context.Response.WriteAsync( "WaitingForEmailConfirmation" );

                user.IsEmailConfirmed      = true;
                user.EmailConfirmationDate = DateTime.Now;

                _userService.UpdateUser( user ).Wait();
            }
        }

        #endregion
    }
}
