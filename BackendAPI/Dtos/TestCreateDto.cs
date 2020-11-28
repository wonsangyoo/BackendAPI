using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Dtos
{
    public class TestCreateDto
    {
        // We don't want to pass Id and TestDate to client - omitted in CreateDto
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

    }
}
