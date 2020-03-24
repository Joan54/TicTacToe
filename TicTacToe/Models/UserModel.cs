namespace TicTacToe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        #region Public properties

        [ Required ]
        [ DataType( DataType.EmailAddress ) ]
        public string Email { get; set; }

        public DateTime? EmailConfirmationDate { get; set; }

        [ Required ]
        public string FirstName { get; set; }

        public Guid Id { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [ Required ]
        public string LastName { get; set; }

        [ Required() ]
        [ DataType( DataType.Password) ]
        public string Password { get; set; }

        public int Score { get; set; }

        #endregion
    }
}
