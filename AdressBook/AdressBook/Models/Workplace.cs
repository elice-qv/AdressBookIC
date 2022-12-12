using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdressBook.Models
{
    public class Workplace
    {
        public int Id { get; set; }

        [Display(Name = "Имя устройства")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Адрес")]
        public string Adress { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
