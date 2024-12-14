using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Data;
using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public class ThemeService : IThemeService
    {
        private readonly ApplicationDbContext _context;

        public ThemeService(ApplicationDbContext context)
        {
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

        public async Task<List<Theme>> GetAllThemes(ThemeFilterParams? filterParams = null)
        {
            var query = _context.Themes.AsQueryable();

            if (filterParams == null)
            {
                return await query.ToListAsync();
            }

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

            //query = query.Include(t => t.StProgram);
            //query = query.Include(t => t.Supervisor);

            return await query.ToListAsync();
        }

        public async Task<Theme> GetThemeById(int id)
        {
            return await _context.Themes.FirstOrDefaultAsync(t => t.Id == id);
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
