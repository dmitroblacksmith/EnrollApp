using System.ComponentModel.DataAnnotations;

namespace EnrollApp.ViewModels
{
    public class ClientRequestViewModel
    {
        [Required(ErrorMessage = "Введите свое имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите свой номер телефона")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
        [Display(Name = "Ваш вопрос")]
        public string Question { get; set; }
        public int? OfferId { get; set; }
    }
}