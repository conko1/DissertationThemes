using Microsoft.EntityFrameworkCore;
using SharedLibrary.Data;
using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public class StProgramService : IStProgramService
    {
        private readonly ApplicationDbContext _context;

        public StProgramService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddStProgram(StProgram stProgram)
        {
            _context.StPrograms.Add(stProgram);
            await _context.SaveChangesAsync();
        }

        public async Task BulkAddStPrograms(List<StProgram> stPrograms)
        {
            _context.StPrograms.AddRange(stPrograms);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllStPrograms()
        {
            await _context.StPrograms.ExecuteDeleteAsync();
        }

        public async Task<List<StProgram>> GetAllStPrograms()
        {
            return await _context.StPrograms.ToListAsync();
        }

        public async Task<StProgram> GetStProgramById(int id)
        {
            return await _context.StPrograms.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Theme>> GetStProgramThemes(int id)
        {
            return await _context.Themes
            .Where(t => t.StProgramId == id)
            .ToListAsync();
        }
    }
}
