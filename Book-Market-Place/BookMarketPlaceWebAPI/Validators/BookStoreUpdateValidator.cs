using ApplicationServices.DTO;
using FluentValidation;

namespace BookMarketPlaceWebAPI.Validators
{
    public class BookStoreUpdateValidator : AbstractValidator<BookStoreUpdateDTO>
    {
        public BookStoreUpdateValidator()
        {
            RuleFor(BookStoreUpdateDTO => BookStoreUpdateDTO.ID).NotNull();

            RuleFor(BookStoreUpdateDTO => BookStoreUpdateDTO.Adress).NotNull().MinimumLength(10).MaximumLength(200);

            RuleFor(BookStoreUpdateDTO => BookStoreUpdateDTO.Adress).NotNull().MinimumLength(10).MaximumLength(200);

            RuleFor(BookStoreUpdateDTO => BookStoreUpdateDTO.StoreName).NotNull().MinimumLength(10).MaximumLength(200);

            //بدون صفر
            RuleFor(BookStoreUpdateDTO => BookStoreUpdateDTO.TelPhone).NotNull().Length(10);

            RuleFor(BookStoreUpdateDTO => BookStoreUpdateDTO.SaleManName).NotNull();

            RuleFor(BookStoreUpdateDTO => BookStoreUpdateDTO.Rating).Must(BeRateValid).WithMessage("رتیه باید بین 0 تا 5 باشد");
        }

        protected bool BeRateValid(ushort Rating)
        {
            if (Rating >= 0 && Rating <= 5)
            {
                return true;
            }
            return false;

        }
    }
}


