//  <copyright file="UserService.cs" company="Joan van Houten">
// 
//      Copyright ©  Joan van Houten - All rights reserved.
//  ************************************************************************************
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// 
// </copyright>
// 
// SVN         : $Id$
// 
// Description :
// 
// Decisions   :
// 
// History     :
//   Date: 2020-03-24, Author: Joan van Houten
//   Reason for change: Initial version
//   Details of change: Creation
//  ************************************************************************************

namespace TicTacToe.Services
{
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;

    public class UserService : IUserService
    {
        #region Static fields

        private static ConcurrentBag< UserModel > _userStore;

        #endregion

        #region Constructors and Destructors

        static UserService()
        {
            _userStore = new ConcurrentBag< UserModel >();
        }

        #endregion

        #region Public methods and operators

        public Task< UserModel > GetUserByEmail( string email )
        {
            return Task.FromResult( _userStore.FirstOrDefault
                                        ( u => u.Email == email ) );
        }

        public Task< bool > IsOnline( string name ) => Task.FromResult( true );

        public Task< bool > RegisterUser( UserModel userModel )
        {
            _userStore.Add( userModel );

            return Task.FromResult( true );
        }

        public Task UpdateUser( UserModel userModel )
        {
            _userStore = new ConcurrentBag< UserModel >( _userStore.Where
                                                             ( u => u.Email != userModel.Email ) )
                         {
                             userModel
                         };

            return Task.CompletedTask;
        }

        #endregion
    }
}
