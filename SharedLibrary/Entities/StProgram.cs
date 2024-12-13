namespace SharedLibrary.Entity
{
    public class StProgram : BaseEntity
    {
        public string FieldOfStudy { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Theme> Themes { get; set; } = new List<Theme>();
    }
}
