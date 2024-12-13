namespace ImporterApp.Entities
{
    internal abstract class BaseDTO<T> where T : new()
    {
        internal virtual T TransformToEntity()
        {
            return new T();
        }
    }
}
