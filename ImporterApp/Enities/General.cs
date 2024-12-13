namespace ImporterApp.Enities
{
    public class General
    {
        public string Name { get; set; }

        public string Supervisor { get; set; }

        public string StProgram { get; set; }

        public string FieldOfStudy { get; set; }

        public bool IsFullTimeStudy { get; set; }

        public bool IsExternalStudy { get; set; }

        public string ResearchType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
