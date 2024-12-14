using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Dtos;
using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public interface IThemeService
    {
        Task<List<ThemeDTO>> GetAllThemes(ThemeFilterParams? filterParams = null);
        Task<ThemeDTO> GetThemeById(int id);
        Task<List<Int32>> GetThemesYears();

        Task AddTheme(Theme theme);
        Task BulkAddThemes(List<Theme> themes);
        Task DeleteAllThemes();
    }
}
