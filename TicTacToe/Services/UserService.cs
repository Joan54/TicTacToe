namespace TicTacToe.Services
{
    using System.Threading.Tasks;
    using Models;

    public class UserService : IUserService
    {
        public Task< bool > RegisterUser( UserModel userModel )
        {
            return Task.FromResult( true );
        }

        public Task< bool > IsOnline( string name )
        {
            return Task.FromResult( true );
        }
    }
}
