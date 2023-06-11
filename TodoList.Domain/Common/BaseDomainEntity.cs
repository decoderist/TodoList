using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
