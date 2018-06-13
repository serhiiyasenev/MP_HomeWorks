using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class TodoItemValue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Value { get; set; }

        //[ForeignKey("Parent")]
        //public int ParentId { get; set; }

        //public TodoItem Parent { get; set; }
    }
}