using AutoMapper;
using ImporterApp.DTO;
using ImporterApp.Enities;
using SharedLibrary.Types;

namespace ImporterApp.Mapping
{
    public class ImporterAppMapper : Profile
    {
        public ImporterAppMapper() 
        {
            CreateMap<General, StProgramDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StProgram))
                .ForMember(dest => dest.FieldOfStudy, opt => opt.MapFrom(src => src.FieldOfStudy));

            CreateMap<General, SupervisorDTO>()
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.Supervisor));

            CreateMap<General, ThemeDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SupervisorId, opt => opt.Ignore())
                .ForMember(dest => dest.Supervisor, opt => opt.MapFrom(src => src.Supervisor))
                .ForMember(dest => dest.StProgramId, opt => opt.Ignore())
                .ForMember(dest => dest.StProgram, opt => opt.MapFrom(src => src.StProgram))
                .ForMember(dest => dest.IsFullTimeStudy, opt => opt.MapFrom(src => src.IsFullTimeStudy))
                .ForMember(dest => dest.IsExternalStudy, opt => opt.MapFrom(src => src.IsExternalStudy))
                .ForMember(dest => dest.ResearchType, opt => opt.MapFrom(src => TypeExtension.ToEnum(src.ResearchType)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
