using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string Mail { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}