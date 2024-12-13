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

        public async Task AddSupervisor(Supervisor supervisor)
        {
            _context.Supervisors.Add(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task BulkAddSupervisors(List<Supervisor> supervisors)
        {
            _context.Supervisors.AddRange(supervisors);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllSupervisors()
        {
            await _context.Supervisors.ExecuteDeleteAsync();
        }

        public async Task<List<Supervisor>> GetAllSupervisors()
        {
            return await _context.Supervisors.ToListAsync();
        }

        public async Task<Supervisor> GetSupervisorById(int id)
        {
            return await _context.Supervisors.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
