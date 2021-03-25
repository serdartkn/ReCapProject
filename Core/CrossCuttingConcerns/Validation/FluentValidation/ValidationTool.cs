using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); // Burada diyoruz ki nesnesiyi doğrulayacağım.
            var result = validator.Validate(context); // Burada da diyoruz ki kurallarım contexte'de bulunan nesneyi doğrulayacak.
            if (!result.IsValid) //Eğer cevap true değilse yani kuralların hepsi uygulanmıyorsa false döner hata fırlar true ise ekleme olur.
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
