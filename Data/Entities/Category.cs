using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LojinhaDaPaulinha.Data.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Category")]
        public string Name { get; set; }
    }
}
