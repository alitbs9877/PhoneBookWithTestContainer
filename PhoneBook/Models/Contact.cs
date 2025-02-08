using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required] 
        public string firstName { get; set; }
        
        [Required] 
        public string lastName { get; set; }


        [Required]
        public string phoneNumber { get; set; }

    }
}
