using CQRS.Core.Entities.Base;

namespace CQRS.Core.Entities
{
    public class Customer : BaseEitity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
