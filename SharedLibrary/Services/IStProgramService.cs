using SharedLibrary.Entity;

namespace SharedLibrary.Services
{
    public interface IStProgramService
    {
        Task<List<StProgram>> GetAllStPrograms(bool orderByName);
        Task<StProgram> GetStProgramById(int id);
        Task<List<Theme>> GetStProgramThemes(int id);
        Task<StProgram> GetStProgramByFieldOfStudy(string fieldOfStudy);

        Task AddStProgram(StProgram stProgram);
        Task BulkAddStPrograms(List<StProgram> stPrograms);
        Task DeleteAllStPrograms();
    }
}
