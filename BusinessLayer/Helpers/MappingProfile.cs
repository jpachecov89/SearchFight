using AutoMapper;
using BusinessLayer.Dtos;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Engine, EngineDto>();
            CreateMap<EngineDto, Engine>();
            CreateMap<ProgramLanguage, ProgramLanguageDto>();
            CreateMap<ProgramLanguageDto, ProgramLanguage>();
            CreateMap<LanguageSearch, LanguageSearchDto>();
            CreateMap<LanguageSearchDto, LanguageSearch>();
        }
    }
}
