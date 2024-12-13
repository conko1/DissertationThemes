using ImporterApp.Enities;

namespace ImporterApp.Importers
{
    internal interface ITransformer<T>
    {
        List<T> GenerateDefaultObjects(List<string> fileContent);
    }
}
