using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public interface IStProgramService
    {
        Task<List<StProgram>> GetAllStPrograms();
        Task<StProgram> GetStProgramById(int id);
        Task<List<Theme>> GetStProgramThemes(int id);

        Task AddStProgram(StProgram stProgram);
        Task BulkAddStPrograms(List<StProgram> stPrograms);
        Task DeleteAllStPrograms();
    }
}
