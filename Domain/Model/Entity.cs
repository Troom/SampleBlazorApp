namespace Domain.Model
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
