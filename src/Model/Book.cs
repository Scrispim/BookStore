using BookStore.Contract;

namespace BookStore.Model
{
	public class Book : IBook
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public Address Location { get; set; }
        public Press Press { get; set; }

		public void AddBook(int id, string isbn, string tilte, string author, decimal price, Address location, Press press)
		{
            Id = id;
            ISBN = isbn;
            Title = tilte;
            Author = author;
            Price = price;
            Location = location;
            Press = press;
		}
	}

    //// Category
    //public enum Category
    //{
    //    Book,
    //    Magazine,
    //    EBook
    //}

}
