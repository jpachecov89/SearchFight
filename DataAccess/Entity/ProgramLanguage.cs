using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entity
{
    public class ProgramLanguage : BaseEntity
    {
        [Key]
        public Guid ProgramLanguageId { get; set; }
        public string DisplayName { get; set; }
    }
}
