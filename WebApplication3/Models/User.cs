﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WebApplication3.Data;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    public class User: DateMutation
    {
        [Key]
        public int Id { get;private set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public float Balance { get; private set; } = 0;
        public ICollection<Todo>? Todos { get; } = new List<Todo>();

        public void UpdateBalance(float balance)
        {
            this.Balance = balance;
        }
    }
}
