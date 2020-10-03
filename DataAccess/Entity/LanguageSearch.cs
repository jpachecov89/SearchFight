using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entity
{
    public class LanguageSearch : BaseEntity
    {
        [Key]
        public Guid LanguageSearchId { get; set; }
        public Engine Engine { get; set; }
        public Guid EngineId { get; set; }
        public ProgramLanguage ProgramLanguage { get; set; }
        public Guid ProgramLanguageId { get; set; }
        public int CurrentSearchs { get; set; }
    }
}
