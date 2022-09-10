using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RestAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Image { get; set; }
        [Timestamp]
        public DateTime CreatedDateUTC { get; set; }
        [Timestamp]
        public DateTime UpdatedDateUTC { get; set; }
        public bool Archived { get; set; }
    }
}
