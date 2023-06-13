using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Domain.Common;

namespace TodoList.Domain
{
    public class TodoItem : BaseDomainEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        [MinLength(15)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public bool Done { get; set; }

        public DateTime DueDate { get; set; }

        [Column("Tags")]
        [MaxLength(3)]
        public IEnumerable<string> Tags { get; set; }
    }
}
