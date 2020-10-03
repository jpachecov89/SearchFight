using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Interface;
using DataAccess;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Manager
{
    public class LanguageSearchManager : ILanguageSearchManager
    {
        private readonly SearchContext context;
        private readonly IMapper iMapper;
        public LanguageSearchManager(SearchContext _context, IMapper _iMapper)
        {
            this.context = _context;
            this.iMapper = _iMapper;
        }

        public async Task<List<LanguageSearchDto>> GetSearchsByProgramLanguages(string[] programLanaguages)
        {
            try
            {
                List<LanguageSearchDto> languageSearchDtos = new List<LanguageSearchDto>();
                foreach (string programLanguageName in programLanaguages)
                {
                    ProgramLanguage programLanguage = await context.ProgramLanguage.FirstOrDefaultAsync(x => x.DisplayName.ToUpper().Equals(programLanguageName.ToUpper()) && x.IsActive == true);
                    if (programLanguage != null)
                    {
                        List<LanguageSearch> languageSearchs = await context.LanguageSearch.Where(x => x.ProgramLanguageId == programLanguage.ProgramLanguageId && x.IsActive == true).OrderByDescending(x => x.CreatedDate).ToListAsync();
                        if (languageSearchs.Count > 0)
                        {
                            foreach (LanguageSearch languageSearch in languageSearchs)
                            {
                                if (languageSearch.Engine == null)
                                {
                                    languageSearch.Engine = await context.Engine.FirstOrDefaultAsync(x => x.EngineId == languageSearch.EngineId);
                                }
                                LanguageSearchDto languageSearchDto = iMapper.Map<LanguageSearchDto>(languageSearch);
                                languageSearchDto.LanguageSearchName = programLanguage.DisplayName;
                                languageSearchDto.EngineName = languageSearch.Engine.DisplayName;
                                languageSearchDtos.Add(languageSearchDto);
                            }
                        }
                    }
                }
                return languageSearchDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
