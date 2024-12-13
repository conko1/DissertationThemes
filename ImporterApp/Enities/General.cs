namespace ImporterApp.Enities
{
    public class General
    {
        public string Name { get; set; } = string.Empty;

        public string Supervisor { get; set; } = string.Empty;

        public string StProgram { get; set; } = string.Empty;

        public string FieldOfStudy { get; set; } = string.Empty;

        public bool IsFullTimeStudy { get; set; }

        public bool IsExternalStudy { get; set; }

        public string ResearchType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
