using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Dtos;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SearchEngines.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ILanguageSearchManager iLanguageSearchManager;
        public SearchController(ILanguageSearchManager _iLanguageManager)
        {
            this.iLanguageSearchManager = _iLanguageManager;
        }

        [HttpPost("GetSearchsByLanguages")]
        public async Task<List<LanguageSearchDto>> GetSearchsByLanguages([FromBody] string[] programLanguages)
        {
            try
            {
                return await iLanguageSearchManager.GetSearchsByProgramLanguages(programLanguages);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
