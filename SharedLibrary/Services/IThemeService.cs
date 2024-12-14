using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public interface IThemeService
    {
        Task<List<Theme>> GetAllThemes(ThemeFilterParams? filterParams = null);
        Task<Theme> GetThemeById(int id);

        Task AddTheme(Theme theme);
        Task BulkAddThemes(List<Theme> themes);
        Task DeleteAllThemes();
    }
}
