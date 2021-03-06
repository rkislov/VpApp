﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VpApp.Models
{
    public class User
    {
        // ID
        public Guid Id { get; set; }
        // Фамилия Имя Отчество
        [Required]
        [Display(Name = "Фамилия Имя Отчество")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }
        // Логин
        [Required]
        [Display(Name = "Логин")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Login { get; set; }
        // Пароль
        [Required]
        [Display(Name = "Пароль")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Password { get; set; }
        // Телефон
        [Display(Name = "Телефон")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public ICollection<Telefon> Telefons { get; set; }
        public Telefon Telefon { get; set; }
        // Должность
        [Display(Name = "Должность")]
        
        public Guid? PositionId { get; set; }
        public Position Position { get; set; }
        // Отдел
        [Display(Name = "Отдел")]
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
        // Статус
        [Required]
        [Display(Name = "Должность")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public User()
        {
            Telefons = new List<Telefon>();
        }
    }
}