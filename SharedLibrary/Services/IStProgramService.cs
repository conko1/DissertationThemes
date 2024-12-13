using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public interface IStProgramService
    {
        Task<List<StProgram>> GetAllStPrograms();
        Task<StProgram> GetStProgramById(int id);
        Task<List<Theme>> GetStProgramThemes(int id);

        Task AddStProgramAsync(StProgram stProgram);
        Task BulkAddStProgramsAsync(List<StProgram> stPrograms);
        Task DeleteAllStProgramsAsync();
    }
}
