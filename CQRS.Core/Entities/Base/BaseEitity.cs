namespace CQRS.Core.Entities.Base
{
    public class BaseEitity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; private set; }

        public BaseEitity()
        {
            this.ModifiedDate = DateTime.Now;
        }
    }
}
