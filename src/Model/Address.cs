using BookStore.Contract;

namespace BookStore.Model
{
    public class Address : IAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
