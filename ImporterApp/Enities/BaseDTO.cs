namespace ImporterApp.Entities
{
    public abstract class BaseDTO<T> where T : new()
    {
        public virtual T TransformToEntity()
        {
            return new T();
        }
    }
}
