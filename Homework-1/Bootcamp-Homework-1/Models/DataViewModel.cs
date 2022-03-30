using System;
using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Homework_1.Models
{
    public class DataViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunlu alandır.")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen sadece harf kullanın.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } // setini silersem sadece erişilebilir bir property olur.get yazman ama zorunlu
        [Required(ErrorMessage = "Soyad alanı zorunlu alandır.")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen sadece harf kullanın.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Parola alanı zorunlu alandır.")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "Şifre en az 8 karakter olmalı ve bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        public string Password { get; set; }
        [Display(Name = "E-mail")]
        [RegularExpression("^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$", ErrorMessage = "Geçerli bir e-mail adresi girmeniz gerekmektedir.")]
        [Required(ErrorMessage = "E-mail alanı zorunlu alandır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
