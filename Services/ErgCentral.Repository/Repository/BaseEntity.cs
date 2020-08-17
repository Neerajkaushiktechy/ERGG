using ErgCentral.Repository.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ErgCentral.Repository.Repository
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Int32? Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32? CreatedBy { get; set; }
        public Int32? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
