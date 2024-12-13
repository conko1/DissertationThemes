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
    }
}
