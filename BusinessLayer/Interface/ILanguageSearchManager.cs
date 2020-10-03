using BusinessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILanguageSearchManager
    {
        Task<List<LanguageSearchDto>> GetSearchsByProgramLanguages(string[] programLanaguages);
    }
}
