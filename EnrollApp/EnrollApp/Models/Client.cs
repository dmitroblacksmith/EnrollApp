using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите свое имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите свой номер телефона")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
        [Required]
        public virtual IEnumerable<ClientRequest> ClientRequests { get; set; } = new List<ClientRequest>();
    }
}
