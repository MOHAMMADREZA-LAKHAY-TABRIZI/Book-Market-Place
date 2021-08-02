using ApplicationServices.DTO;
using ApplicationServices.Services.BookCategoryServices;
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
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService bookCategoryServices;
        private readonly IMapper mapper;

        public BookCategoryController(IBookCategoryService bookCategoryServices, IMapper mapper)
        {
            this.bookCategoryServices = bookCategoryServices;
            this.mapper = mapper;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            var bookQuery = bookCategoryServices.GetQuery();

            var book = from bookCategoryRecord in bookQuery
                       where bookCategoryRecord.ID == ID
                       select bookCategoryRecord;

            var isFound = book.FirstOrDefault();

            if (isFound == null)
            {
                return NoContent();
            }
            else
            {
                await bookCategoryServices.Delete(isFound.ID);

                return Ok($"حذف گردید {isFound.Name} دسته");
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var allCategory = await bookCategoryServices.GetAll();

            if (allCategory == null)
            {

                return NoContent();
            }

            return Ok(allCategory);

        }

        [HttpGet("{ID}")]
        public async ValueTask<IActionResult> GetByID(int ID)
        {

            var bookRecord = await bookCategoryServices.GetByID(ID);

            if (bookRecord == null)
            {
                return NoContent();
            }

            return Ok(bookRecord);

        }

        [HttpPost]
        public async Task<IActionResult> Insert(BookCategoryDTO entity)
        {


            var queryResponse = bookCategoryServices.GetQuery();

            var sameCategory = queryResponse.Where<BookCategory>(Category => Category.Name == entity.Name).FirstOrDefault();//چرا؟؟؟

            if (sameCategory != null)
            {
                return BadRequest("این دسته از قبل در پایگاه داده وجود دارد");
            }

            BookCategoryValidator validations = new BookCategoryValidator();

            var result = validations.Validate(entity);

            if (result.IsValid)
            {
                await bookCategoryServices.Insert(entity);

                return Ok("دستور با موفقیت اجرا شد");
            }

            else
            {
                return BadRequest();
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update(BookCategoryUpdateDTO entity)
        {
            var queryResponse = bookCategoryServices.GetQuery();

            var sameCategory = queryResponse.Where<BookCategory>(Category => Category.ID == entity.ID);//only update must be defered execution

            if (sameCategory == null)
            {
                return BadRequest("این دسته از قبل در پایگاه داده وجود ندارد");
            }

            BookCategoryUpdateValidator validations = new BookCategoryUpdateValidator();

            var result = validations.Validate(entity);

            if (result.IsValid)
            {
                await bookCategoryServices.Update(entity);

                return Ok("دستور با موفقیت اجرا شد");
            }

            else
            {
                return BadRequest();
            }

           
        }


    }
}