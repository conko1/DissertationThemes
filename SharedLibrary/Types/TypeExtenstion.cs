namespace SharedLibrary.Types
{
    public static class TypeExtension
    {
        public static ResearchType? ToEnum(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            switch(value)
            {
                case "základný výskum": return ResearchType.BasicResearch;
                case "aplikovaný výskum": return ResearchType.AppliedResearch;
                case "aplikovaný výskum a experimentálny vývoj": return ResearchType.AppliedResearchExpDevelopment;
                default : return null;
            }
        }

        public static string? FromEnum(this ResearchType value)
        {
            switch (value)
            {
                case ResearchType.BasicResearch: return "základný výskum";
                case ResearchType.AppliedResearch: return "aplikovaný výskum";
                case ResearchType.AppliedResearchExpDevelopment: return "aplikovaný výskum a experimentálny vývoj";
                default: return null;
            }
        }
    }
}
