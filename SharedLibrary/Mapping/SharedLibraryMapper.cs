using AutoMapper;
using SharedLibrary.Dtos;
using SharedLibrary.Entity;
using SharedLibrary.Types;

namespace SharedLibrary.Mapping
{
    internal class SharedLibraryMapper : Profile
    {
        public SharedLibraryMapper()
        {
            CreateMap<StProgram, StProgramDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FieldOfStudy, opt => opt.MapFrom(src => src.FieldOfStudy));

            CreateMap<Supervisor, SupervisorDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

            CreateMap<Theme, ThemeDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Supervisor, opt => opt.Ignore())
                .ForMember(dest => dest.StProgram, opt => opt.Ignore())
                .ForMember(dest => dest.IsFullTimeStudy, opt => opt.MapFrom(src => src.IsFullTimeStudy))
                .ForMember(dest => dest.IsExternalStudy, opt => opt.MapFrom(src => src.IsExternalStudy))
                .ForMember(dest => dest.ResearchType, opt => opt.MapFrom(src => src.ResearchType))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }

    internal class MapperWrapper
    {
        private readonly IMapper _mapper;

        internal MapperWrapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SharedLibraryMapper>();
            });

            _mapper = config.CreateMapper();
        }

        internal D Map<S, D>(S source)
        {
            return _mapper.Map<D>(source);
        }
    }
}
