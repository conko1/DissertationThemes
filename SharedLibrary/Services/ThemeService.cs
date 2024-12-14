using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Data;
using SharedLibrary.Entity;
using System.IO.IsolatedStorage;
using SharedLibrary.Mapping;
using SharedLibrary.Dtos;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SharedLibrary.Services
{
    public class ThemeService : IThemeService
    {
        private readonly ApplicationDbContext _context;
        private readonly MapperWrapper _mapper;

        public ThemeService(ApplicationDbContext context)
        {
            _mapper = new MapperWrapper();
            _context = context;
        }

        public async Task AddTheme(Theme theme)
        {
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();
        }

        public async Task BulkAddThemes(List<Theme> themes)
        {
            for (int i = 0; i < themes.Count; i++)
            {
                _context.Themes.Add(themes[i]);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllThemes()
        {
            await _context.Themes.ExecuteDeleteAsync();
        }

        public async Task<List<ThemeDTO>> GetAllThemes(ThemeFilterParams filterParams)
        {
            var query = _context.Themes.AsQueryable();

            if (filterParams.Year != null)
            {
                query = query.Where(t => t.CreatedAt.Year == filterParams.Year);
            }

            if (filterParams.StudyProgram != null)
            {
                var stProgramsIds = await _context.StPrograms
                    .Where(t => t.Name == filterParams.StudyProgram)
                    .Select(t => t.Id)
                    .ToListAsync();
                query = query.Where(t => stProgramsIds.Contains(t.StProgramId));
            }

            query = query
                .Include(t => t.StProgram)
                .Include(t => t.Supervisor);

            return SerializeToThemeDTO(await query.ToListAsync());
        }

        public async Task<ThemeDTO> GetThemeById(int id)
        {
            var theme = await _context.Themes
                .Include(t => t.StProgram)
                .Include(t => t.Supervisor)
                .FirstOrDefaultAsync(t => t.Id == id);

            return SerializeToThemeDTO(theme);
        }

        public async Task<List<Int32>> GetThemesYears()
        {
            return await _context.Themes
            .Select(t => t.CreatedAt.Year)
            .Distinct()
            .OrderBy(year => year)
            .ToListAsync();
        }

        internal List<ThemeDTO> SerializeToThemeDTO(List<Theme> themes)
        {
            List<ThemeDTO> themesDtos = new List<ThemeDTO>();

            foreach (Theme theme in themes)
            {
                themesDtos.Add(SerializeToThemeDTO(theme));
            }

            return themesDtos;
        }

        internal ThemeDTO SerializeToThemeDTO(Theme theme)
        {
            var themeDto = _mapper.Map<Theme, ThemeDTO>(theme);
            themeDto.StProgram = _mapper.Map<StProgram, StProgramDTO>(theme.StProgram);
            themeDto.Supervisor = _mapper.Map<Supervisor, SupervisorDTO>(theme.Supervisor);
            return themeDto;
        }
    }

    public class ThemeFilterParams
    {
        [FromQuery(Name = "study_program")]
        public string? StudyProgram { get; set; }

        [FromQuery(Name = "year")]
        public int? Year { get; set; }
    }
}
