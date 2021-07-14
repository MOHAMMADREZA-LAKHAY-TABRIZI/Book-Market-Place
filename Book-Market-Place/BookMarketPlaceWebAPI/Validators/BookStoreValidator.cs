using ApplicationServices.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarketPlaceWebAPI.Validators
{
    public class BookStoreValidator : AbstractValidator<BookStoreDTO>
    {

        public BookStoreValidator()
        {
            //حد و مرز آدرس

            RuleFor(BookStoreDTO => BookStoreDTO.Adress).NotNull().MinimumLength(10).MaximumLength(200);

            RuleFor(BookStoreDTO => BookStoreDTO.StoreName).NotNull().MinimumLength(10).MaximumLength(200);

            //بدون صفر
            RuleFor(BookStoreDTO => BookStoreDTO.TelPhone).NotNull().Length(10);

            RuleFor(BookStoreDTO => BookStoreDTO.SaleManName).NotNull();

            RuleFor(BookStoreDTO => BookStoreDTO.Rating).Must(BeRateValid).WithMessage("رتیه باید بین 0 تا 5 باشد");

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


