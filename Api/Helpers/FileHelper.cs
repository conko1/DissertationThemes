using DocumentFormat.OpenXml.Packaging;
using SharedLibrary.Dtos;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Api.Helpers
{
    public class FileHelper
    {
        public static void ReplacePlaceholdersInDocx(Dictionary<string, string> replacements, string targetFile, string filePath = "Schemas/theme_schema.docx")
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file was not found.", filePath);

            File.Copy(filePath, targetFile, true);

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(targetFile, true))
            {
                string? docText = null;

                using (StreamReader sr = new StreamReader(wordDocument.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();

                    foreach (var replacement in replacements)
                    {
                        Regex regexText = new Regex(replacement.Key);
                        docText = regexText.Replace(docText, replacement.Value);
                    }

                }

                using (StreamWriter sw = new StreamWriter(wordDocument.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }

        public static byte[] ConvertThemesToCsv(IList<ThemeDTO> themes)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Name;Supervisor;StProgram;FieldOfStudy;IsFullTimeStudy;IsExternalStudy;ResearchType;Description;CreatedAt");

            foreach (var theme in themes)
            {
                var row = new List<string>
            {
                theme.Name,
                theme.Supervisor?.FullName ?? "",
                theme.StProgram?.Name ?? "",
                theme.StProgram?.FieldOfStudy ?? "",
                theme.IsFullTimeStudy.ToString(),
                theme.IsExternalStudy.ToString(),
                theme.ResearchType.ToString(),
                theme.Description.Replace("\n", "<br>"),
                theme.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };

                sb.AppendLine(string.Join(";", row));
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
