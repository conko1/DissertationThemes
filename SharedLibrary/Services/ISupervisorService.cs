using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public interface ISupervisorService
    {
        Task<List<Supervisor>> GetAllSupervisors();
        Task<Supervisor> GetSupervisorById(int id);

        Task AddSupervisor(Supervisor supervisor);
        Task BulkAddSupervisors(List<Supervisor> supervisors);
        Task DeleteAllSupervisors();
    }
}
