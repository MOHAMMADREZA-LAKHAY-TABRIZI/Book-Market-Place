using ApplicationServices.DTO;
using FluentValidation;

namespace BookMarketPlaceWebAPI.Validators
{
    public class BookCategoryValidator : AbstractValidator<BookCategoryDTO>
    {

        public BookCategoryValidator()
        {

            RuleFor(BookCategoryDTO => BookCategoryDTO.Name).NotNull().MinimumLength(4).MaximumLength(15);

        }

    }
}


