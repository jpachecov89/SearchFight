using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entity
{
    public class Engine : BaseEntity
    {
        [Key]
        public Guid EngineId { get; set; }
        public string DisplayName { get; set; }
    }
}
