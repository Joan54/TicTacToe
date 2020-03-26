namespace TicTacToe.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    public class GameInvitationController : Controller
    {
        #region Fields

        private IUserService _userService;

        #endregion

        #region Constructors and Destructors

        public GameInvitationController( IUserService userService )
        {
            _userService = userService;
        }

        #endregion

        #region Public methods and operators

        [ HttpGet ]
        public IActionResult Index( string email )
        {
            var gameInvitationModel = new GameInvitationModel
                                      {
                                          InvitedBy = email
                                      };

            return View( gameInvitationModel );
        }

        #endregion
    }
}
