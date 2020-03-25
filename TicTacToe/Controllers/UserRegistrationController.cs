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

        [ HttpGet ]
        public async Task< IActionResult > EmailConfirmation( string email )
        {
            var user = await _userService.GetUserByEmail( email );

            if ( user?.IsEmailConfirmed == true )
            {
                return RedirectToAction( "Index", "GameInvitation", new
                                                                    {
                                                                        email
                                                                    } );
            }

            ViewBag.Email = email;

            return View();
        }

        [ HttpPost ]
        public async Task< IActionResult > Index( UserModel userModel )
        {
            if ( ModelState.IsValid )
            {
                await _userService.RegisterUser( userModel );

                return RedirectToAction( nameof( EmailConfirmation ), new
                                                                      {
                                                                          userModel.Email
                                                                      } );
            }

            return View( userModel );
        }

        public IActionResult Index() => View();

        #endregion
    }
}
