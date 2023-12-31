﻿using System.ComponentModel.DataAnnotations;

namespace RestAPI.DTO.User
{
    public class UserSignUpDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
