using ApplicationServices.DTO;
using ApplicationServices.Services;
using AutoMapper;
using BookMarketPlaceWebAPI.Validators;
using Entities.POCOEntities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarketPlaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices bookServices;
        private readonly IMapper mapper;


        public BookController(IBookServices bookServices, IMapper mapper)
        {
            this.bookServices = bookServices;

            this.mapper = mapper;

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            var bookQuery = bookServices.GetQuery();

            var book = from bookRecord in bookQuery
                       where bookRecord.ID == ID
                       select bookRecord;

            var isFound = book.FirstOrDefault();

            if (isFound == null)
            {
                // "هیچ کتابی یا مشخصات وارد شده وجود ندارد"
                return NoContent();
            }
            else
            {
                await bookServices.Delete(isFound.ID);

                return Ok($"حذف گردید {isFound.Title} کتاب");
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var allBooks = await bookServices.GetAll();

            if (allBooks == null)
            {
                //"هیچ کتابی برای نمایش وجود ندارد"
                return NoContent();
            }

            return Ok(allBooks);

        }

        [HttpGet("{ID}")]
        public async ValueTask<IActionResult> GetByID(int ID)
        {

            var bookRecord = await bookServices.GetByID(ID);

            if (bookRecord == null)
            {
                return NoContent();
            }

            return Ok(bookRecord);

        }

        [HttpPost]
        public async Task<IActionResult> Insert(BookDTO entity)
        {
            var queryResponse = bookServices.GetQuery();


            var sameBook = queryResponse.Where<Book>(book => book.IsOld == entity.IsOld && book.Title == entity.Title
             && book.Price == entity.Price && entity.AutherName == book.AutherName && DateTime.Equals(entity.PublishDate, book.PublishDate)).FirstOrDefault();

            if (sameBook != null)
            {
                return BadRequest("این کتاب از قبل در پایگاه داده وجود دارد");
            }

            BookValidator bookValidator = new BookValidator();

            var results = bookValidator.Validate(entity);

            if (results.IsValid)
            {
                await bookServices.Insert(entity);

                return Ok("دستور با موفقیت اجرا شد");
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDTO entity)
        {
            var queryResponse = bookServices.GetQuery();

            var sameBook = queryResponse.Where<Book>(book => book.ID == entity.ID);//.FirstOrDefault()

            if (sameBook == null)
            {
                return BadRequest("این کتاب از قبل در پایگاه داده وجود ندارد");
            }

            BookUpdateValidator validations = new BookUpdateValidator();

            var result = validations.Validate(entity);

            if (result.IsValid)
            {
                await bookServices.Update(entity);

                return Ok("دستور با موفقیت اجرا شد");
            }

            else
            {
                return BadRequest();
            }
        }


    }
}