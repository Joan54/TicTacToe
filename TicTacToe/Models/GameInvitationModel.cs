﻿//  <copyright file="GameInvitationModel.cs" company="Joan van Houten">
// 
//      Copyright © 2020 Joan van Houten - All rights reserved.
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
//   Date: 2020-03-25, Author: Joan van Houten
//   Reason for change: Initial version
//   Details of change: Creation
//  ************************************************************************************

namespace TicTacToe.Models
{
    using System;

    public class GameInvitationModel
    {
        public Guid     Id               { get; set; }
        public string   EmailTo          { get; set; }
        public string   InvitedBy        { get; set; }
        public bool     IsConfirmed      { get; set; }
        public DateTime ConfirmationDate { get; set; }
    }
}