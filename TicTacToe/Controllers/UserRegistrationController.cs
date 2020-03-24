namespace TicTacToe.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    public class UserRegistrationController : Controller
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Constructors and Destructors

        public UserRegistrationController( IUserService userService )
        {
            _userService = userService;
        }

        #endregion

        #region Public methods and operators

        [ HttpPost ]
        public async Task< IActionResult > Index( UserModel userModel )
        {
            if ( ModelState.IsValid )
            {
                await _userService.RegisterUser( userModel );

                return Content
                    ( $"User {userModel.FirstName} {userModel.LastName} has been registered successfully" );
            }

            return View( userModel );
        }

        public IActionResult Index() => View();

        #endregion
    }
}
