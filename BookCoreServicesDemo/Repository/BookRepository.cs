using BookCoreServicesDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCoreServicesDemo.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _db;
        public BookRepository(BookDBContext db)
        {
            _db = db;
        }
        public async Task<List<MasterBook>> GetBook()
        {
            if (_db != null)
            {
                return await _db.MasterBooks.ToListAsync();
            }
            return null;
        }
        public async Task<MasterBook> GetBookByBookId(int bookId)
        {
            if (_db != null)
            {
                return await _db.MasterBooks.FirstOrDefaultAsync(x => x.BookId == bookId);
            }
            return null;
        }
        public async Task<int> PostBook(MasterBook masterBook)
        {
            if (_db != null)
            {
                _db.MasterBooks.Add(masterBook);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> UpdateBook(MasterBook masterBook)
        {
            if (_db != null)
            {
                
                _db.MasterBooks.Update(masterBook);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> DeleteBook(int bookId)
        {
            if (_db != null)
            {
                var data = await _db.MasterBooks.FirstOrDefaultAsync(x => x.BookId == bookId);
                if (data != null)
                {
                    _db.MasterBooks.Remove(data);
                    return await _db.SaveChangesAsync();
                }                
            }
            return 0;
        }
    }
}
