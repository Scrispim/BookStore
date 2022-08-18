using BookStore.Data;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq;

namespace BookStore.Controllers
{
	public class BooksController : ODataController
	{
        private BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }
        // Return all books
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        // Returns a specific book given its key
        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
        }
        // Create a new book
        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Created(book);
        }
    }
}
