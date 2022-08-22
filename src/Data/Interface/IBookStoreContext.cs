using BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Interface
{
	public interface IBookStoreContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Press> Presses { get; set; }
	}
}
