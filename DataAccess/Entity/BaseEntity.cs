using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
