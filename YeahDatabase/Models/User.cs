﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace ChronoPiller.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public List<Prescription> Prescriptions = new List<Prescription>();

//        public User(string login, string password)
//        {
//            Login = login;
//            Password = password;
//        }
    }
}