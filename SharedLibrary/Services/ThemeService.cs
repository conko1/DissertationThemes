using Microsoft.EntityFrameworkCore;
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
            _context.Themes.AddRange(themes);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllThemes()
        {
            await _context.Themes.ExecuteDeleteAsync();
        }

        public async Task<List<Theme>> GetAllThemes(int? year, int? stProgramId)
        {
            var query = _context.Themes.AsQueryable();

            if (year.HasValue)
                query = query.Where(t => t.CreatedAt.Year == year);

            if (stProgramId.HasValue)
                query = query.Where(t => t.StProgramId == stProgramId);

            return await query.ToListAsync();
        }

        public async Task<Theme> GetThemeById(int id)
        {
            return await _context.Themes.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
