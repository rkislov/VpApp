using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VpApp.Models
{
    //перечень должностей
    public class Position
    {
        
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Название должности")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "по штату")]
        
        public int Colichestvo { get; set; }
    }
}