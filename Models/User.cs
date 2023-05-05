﻿using System.ComponentModel.DataAnnotations;

namespace pharmacy.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string role { get; set; }

    }
}
