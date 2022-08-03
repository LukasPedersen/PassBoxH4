using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Box
    {
        public int Id { get; set; }

        [Required]
        public int Website { get; set; }

        [Required]
        public int Username { get; set; }

        [Required]
        public int Password { get; set; }


        //Navigation
        public User User { get; set; }
    }
}
