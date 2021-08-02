using ApplicationServices.DTO;
using ApplicationServices.Services.BookStoreServices;
using AutoMapper;
using BookMarketPlaceWebAPI.Validators;
using Entities.POCOEntities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarketPlaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly IBookStoreService bookStoreService;
        private readonly IMapper mapper;

        public BookStoreController(IBookStoreService bookStoreService, IMapper mapper)
        {
            this.bookStoreService = bookStoreService;
            this.mapper = mapper;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            var bookStoreQuery = bookStoreService.GetQuery();

            var bookStore = from bookStoreRecord in bookStoreQuery
                            where bookStoreRecord.ID == ID
                            select bookStoreRecord;

            var isFound = bookStore.FirstOrDefault();

            if (isFound == null)
            {

                return NoContent();
            }
            else
            {
                await bookStoreService.Delete(isFound.ID);

                return Ok($"حذف گردید {isFound.StoreName} فروشگاه");
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var allBookStore = await bookStoreService.GetAll();

            if (allBookStore == null)
            {

                return NoContent();
            }

            return Ok(allBookStore);

        }

        [HttpGet("{ID}")]
        public async ValueTask<IActionResult> GetByID(int ID)
        {

            var bookStoreRecord = await bookStoreService.GetByID(ID);

            if (bookStoreRecord == null)
            {
                return NoContent();
            }

            return Ok(bookStoreRecord);

        }

        [HttpPost]
        public async Task<IActionResult> Insert(BookStoreDTO entity)
        {
            var queryResponse = bookStoreService.GetQuery();

            var sameBookStore = queryResponse.Where<Bookstore>(bookStore => bookStore.StoreName == entity.StoreName && bookStore.SaleManName == entity.SaleManName);

            if (sameBookStore != null)
            {
                return BadRequest("این فروشگاه از قبل در پایگاه داده وجود دارد");
            }

            BookStoreValidator validations = new BookStoreValidator();

            var result = validations.Validate(entity);

            if (result.IsValid)
            {
                await bookStoreService.Insert(entity);

                return Ok("دستور با موفقیت اجرا شد");
            }

            else
            {
                return BadRequest();
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update(BookStoreUpdateDTO entity)
        {
            var queryResponse = bookStoreService.GetQuery();

            var sameBookStore = queryResponse.Where<Bookstore>(bookStore => bookStore.ID == entity.ID);

            if (sameBookStore == null)
            {
                return BadRequest("این فروشگاه از قبل در پایگاه داده وجود ندارد");
            }

            BookStoreUpdateValidator validations = new BookStoreUpdateValidator();

            var result = validations.Validate(entity);

            if (result.IsValid)
            {
                await bookStoreService.Update(entity);

                return Ok("دستور با موفقیت اجرا شد");
            }

            else
            {
                return BadRequest();
            }
        }



    }
}