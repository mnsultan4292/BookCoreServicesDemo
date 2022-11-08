using BookCoreServicesDemo.Helper;
using BookCoreServicesDemo.Models;
using BookCoreServicesDemo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace BookCoreServicesDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly JwtHelper _jwtHelper;
        public BookController(IBookRepository bookRepository,JwtHelper jwtHelper)
        {
            this.bookRepository = bookRepository;
            _jwtHelper = jwtHelper;
        }   

        [HttpGet]
        
        [Route("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                string accessTokenWithBearerPrefix = Request.Headers[HeaderNames.Authorization];
                string accessTokenWithoutBearerPrefix = accessTokenWithBearerPrefix.Substring("Bearer ".Length);
                string str=_jwtHelper.ValidateJwtToken(accessTokenWithoutBearerPrefix);
                var data =await bookRepository.GetBook();
                if(data!=null)
                    return Ok(data);
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            try
            {
                var data = await bookRepository.GetBookByBookId(bookId);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("PostBooks")]
        public async Task<IActionResult> GetBooks(MasterBook masterBook)
        {
            try
            {
                int result = 0;
                result = await bookRepository.PostBook(masterBook);
                
                if(result>0)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateBooks")]
        public async Task<IActionResult> UpdateBooks(MasterBook masterBook)
        {
            try
            {
                int result = 0;
                result = await bookRepository.UpdateBook(masterBook);

                if (result > 0)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteBooks/{bookId}")]
        public async Task<IActionResult> GetBooks(int bookId)
        {
            try
            {
                int result = 0;
                result = await bookRepository.DeleteBook(bookId);

                
                if (result > 0)
                    return Ok(result);

                return NotFound(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
