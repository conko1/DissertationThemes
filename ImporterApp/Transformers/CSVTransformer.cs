using ImporterApp.Enities;

namespace ImporterApp.Importers
{
    internal class CSVTransformer<T> : ITransformer<T> where T : new()
    {
        public List<T> GenerateDefaultObjects(List<string> fileContent) 
        {
            var records = new List<T>();

            foreach (var line in fileContent.Skip(1))
            {
                var columns = line.Split(';');

                var record = new T();
                var properties = typeof(T).GetProperties();

                for (int i = 0; i < columns.Length && i < properties.Length; i++)
                {
                    var property = properties[i];
                    if (property.CanWrite)
                    {
                        property.SetValue(record, Convert.ChangeType(columns[i], property.PropertyType));
                    }
                }

                records.Add(record);
            }

            return records;
        }
    }
}