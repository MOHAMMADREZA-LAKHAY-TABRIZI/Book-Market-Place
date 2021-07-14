using ApplicationServices.DTO;
using FluentValidation;

namespace BookMarketPlaceWebAPI.Validators
{
    public class BookValidator : AbstractValidator<BookDTO>
    {


        public BookValidator()
        {

            RuleFor(BookDTO => BookDTO.Title).NotNull().MinimumLength(1).MaximumLength(50);

            RuleFor(BookDTO => BookDTO.Price).NotNull().Must(BePriceValid).WithMessage("قیمت وارد شده نامعتبر هست");

            RuleFor(BookDTO => BookDTO.AutherName).NotNull();

            RuleFor(BookDTO => BookDTO.IsOld).NotNull();

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


