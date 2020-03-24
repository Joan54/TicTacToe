﻿namespace TicTacToe.Models
{
    using System;

    public class UserModel
    {
        #region Public properties

        public string    Email                 { get; set; }
        public DateTime? EmailConfirmationDate { get; set; }
        public string    FirstName             { get; set; }
        public Guid      Id                    { get; set; }
        public bool      IsEmailConfirmed      { get; set; }
        public string    LastName              { get; set; }
        public string    Password              { get; set; }
        public int       Score                 { get; set; }

        #endregion
    }
}
