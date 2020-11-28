using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Models
{
    public class Test
    {
        public Test()
        {
            TestDate = DateTime.Now;    
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        public string Province { get; set; }

        [Required]
        public string Result { get; set; }
  
        public DateTime TestDate { get; set; }
    }
}
