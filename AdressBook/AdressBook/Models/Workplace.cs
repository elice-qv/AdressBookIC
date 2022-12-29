using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdressBook.Models
{
    public class Workplace
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 6)]
        [Required]
        [Display(Name = "Имя устройства")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [StringLength(60, MinimumLength = 6)]
        [Display(Name = "Адрес")]
        public string Adress { get; set; }

        [StringLength(60, MinimumLength = 6)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
