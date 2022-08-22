using Bogus;
using BookStore.Contract;
using BookStore.Model;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data
{
	public static class DataSource
    {
        private static IList<Book> _books { get; set; }

        public static IList<Book> GetBooks()
        {
            if (_books != null)
            {
                return _books;
            }

            _books = new List<Book>();

            // book #1
            Book book = new Book();
            book.AddBook(
                1,
                "978-0-321-87758-1",
                "Essential C#5.0",
                "Mark Michaelis",
                59.99m,
                new Address { City = "Redmond", Street = "156TH AVE NE" },
                new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Category = ICategory.Book
                }
                );
            
            _books.Add(book);

            // book #2
            book.AddBook(
                2,
                "063-6-920-02371-5",
                "Enterprise Games",
                "Michael Hugos",
                49.99m,
                new Address { City = "Bellevue", Street = "Main ST" },
                new Press
                {
                    Id = 2,
                    Name = "O'Reilly",
                    Category = ICategory.EBook,
                }
            );

            _books.Add(book);

            for (int i = 2; i < 1000; i++)
            {
                // Fake Item
                var ids = i + 1;
                decimal min = 50m;
                decimal max = 10000m;
                int decimals = 2;
                book = new Faker<Book>()
                    .RuleFor(x => x.Id, f => ids)
                    .RuleFor(x => x.ISBN, f => f.Finance.CreditCardNumber())
                    .RuleFor(x => x.Title, f => f.Company.CompanyName())
                    .RuleFor(x => x.Author, f => f.Person.FullName)
                    .RuleFor(x => x.Price, f => f.Commerce.Price(min, max, decimals).FirstOrDefault())
                    .RuleFor(x => x.Location, f => new Address { City = f.Address.City(), Street = f.Address.StreetName() })
                    .RuleFor(x => x.Press, f => new Press { Id = ids, Name = f.Commerce.ProductName(), Category = ICategory.EBook });

                // generate 1000 items
                _books.Add(book);
            }
            

            return _books;
        }
    }
}
