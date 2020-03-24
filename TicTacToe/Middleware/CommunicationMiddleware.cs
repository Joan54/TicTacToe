namespace TicTacToe.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Services;

    public class CommunicationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public CommunicationMiddleware( RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task Invoke( HttpContext context )
        {
            await _next.Invoke( context );
        }
    }
}
