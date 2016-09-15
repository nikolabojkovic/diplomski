using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiCore1.Models
{
    public class User : Repository.Data
    {
        public int Id { get; set; }

        public string AspNetUserId { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        [Display(Name = "Remeber me")]
        public bool RememberMe { get; set; }

        public bool IsAdmin { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
