using ApplicationServices.DTO;
using FluentValidation;

namespace BookMarketPlaceWebAPI.Validators
{
    public class BookUpdateValidator : AbstractValidator<BookUpdateDTO>
    {


        public BookUpdateValidator()
        {
            RuleFor(BookUpdateDTO => BookUpdateDTO.ID).NotNull();

            RuleFor(BookUpdateDTO => BookUpdateDTO.Title).NotNull().MinimumLength(1).MaximumLength(50);

            RuleFor(BookUpdateDTO => BookUpdateDTO.Price).NotNull().Must(BePriceValid).WithMessage("قیمت وارد شده نامعتبر هست");

            RuleFor(BookUpdateDTO => BookUpdateDTO.AutherName).NotNull();

            RuleFor(BookUpdateDTO => BookUpdateDTO.IsOld).NotNull();

        }
        protected bool BePriceValid(decimal Price)
        {
            if (Price >= 0)
            {
                return true;
            }
            return false;

        }
    }
}


