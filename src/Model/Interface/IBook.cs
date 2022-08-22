using BookStore.Model;

namespace BookStore.Contract
{
	public interface IBook
	{
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public Address Location { get; set; }
        public Press Press { get; set; }

        void AddBook(int id, string isbn, string tilte, string author, decimal price, Address location, Press press);

    }


}
