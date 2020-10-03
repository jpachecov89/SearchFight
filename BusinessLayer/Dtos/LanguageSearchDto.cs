using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dtos
{
    public class LanguageSearchDto
    {
        public Guid LanguageSearchId { get; set; }
        public string LanguageSearchName { get; set; }
        public Guid? EngineId { get; set; }
        public string EngineName { get; set; }
        public Guid? ProgramLanguageId { get; set; }
        public int? CurrentSearchs { get; set; }
        public bool IsActive { get; set; }
    }
}
