using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dtos
{
    public class EngineDto
    {
        public Guid EngineId { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
    }
}
