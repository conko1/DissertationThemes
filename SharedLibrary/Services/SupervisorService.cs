using Microsoft.EntityFrameworkCore;
using SharedLibrary.Data;
using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public class SupervisorService : ISupervisorService
    {
        private readonly ApplicationDbContext _context;

        public SupervisorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supervisor>> GetAllSupervisors()
        {
            return await _context.Supervisors.ToListAsync();
        }

        public async Task<Supervisor> GetSupervisorById(int id)
        {
            return await _context.Supervisors.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Supervisor> GetSupervisorFullName(string fullName)
        {
            return await _context.Supervisors
                .Where(t => t.FullName == fullName)
                .FirstAsync();
        }

        public async Task AddSupervisor(Supervisor supervisor)
        {
            _context.Supervisors.Add(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task BulkAddSupervisors(List<Supervisor> supervisors)
        {
            for (int i = 0; i < supervisors.Count; i++)
            {
                _context.Supervisors.Add(supervisors[i]);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllSupervisors()
        {
            await _context.Supervisors.ExecuteDeleteAsync();
        }
    }
}
