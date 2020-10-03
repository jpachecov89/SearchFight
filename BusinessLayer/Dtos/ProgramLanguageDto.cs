using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dtos
{
    public class ProgramLanguageDto
    {
        public Guid ProgramLanguageId { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
    }
}
