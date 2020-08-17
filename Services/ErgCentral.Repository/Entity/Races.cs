using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Repository.Entity
{
   public class Races
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32? CreatedBy { get; set; }
        public Int32? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
