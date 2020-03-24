namespace TicTacToe.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        #region Public methods and operators

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        #endregion
    }
}
