using System;
using System.ComponentModel.DataAnnotations;

namespace ErgCentral.Repository.Entity
{
    public class ApplicationUser
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32? CreatedBy { get; set; }
        public Int32? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(500)]
        public string Email { get; set; }
        [MaxLength(500)]
        public string Password { get; set; }

    }
}
