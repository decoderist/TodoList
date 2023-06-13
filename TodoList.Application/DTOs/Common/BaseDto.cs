using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.DTOs.Common
{
    public abstract class BaseDto
    {
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
