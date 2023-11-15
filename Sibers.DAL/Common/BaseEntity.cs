namespace Sibers.DAL.Common
{
    public class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }
    }
}
