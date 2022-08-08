using BookCoreServicesDemo.Models;

namespace BookCoreServicesDemo.Repository
{
    public interface IBookRepository
    {
        Task<List<MasterBook>> GetBook();
        Task<MasterBook> GetBookByBookId(int bookId);
        Task<int> PostBook(MasterBook masterBook);
        Task<int> UpdateBook(MasterBook masterBook);
        Task<int> DeleteBook(int bookId);

    }
}
