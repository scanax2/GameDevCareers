﻿using System.ComponentModel.DataAnnotations;

namespace JobBoardPlatform.PL.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
