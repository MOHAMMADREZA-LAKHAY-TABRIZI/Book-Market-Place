using ApplicationServices.DTO;
using FluentValidation;

namespace BookMarketPlaceWebAPI.Validators
{
    public class BookCategoryUpdateValidator : AbstractValidator<BookCategoryUpdateDTO>
    {

        public BookCategoryUpdateValidator()
        {
            RuleFor(BookCategoryUpdateDTO => BookCategoryUpdateDTO.Name).NotNull();

            RuleFor(BookCategoryUpdateDTO => BookCategoryUpdateDTO.Name).NotNull().MinimumLength(4).MaximumLength(15);
        }
    }
}


