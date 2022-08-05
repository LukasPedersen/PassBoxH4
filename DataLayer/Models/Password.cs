using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Password
    {
        public int Id { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Pass { get; set; }

        [Required]
        public string Key { get; set; }


        //Navigation
        public User User { get; set; }
    }
}
