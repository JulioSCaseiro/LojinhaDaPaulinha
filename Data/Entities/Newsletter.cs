using System.ComponentModel.DataAnnotations;

namespace LojinhaDaPaulinha.Data.Entities
{
    public class Newsletter : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime AddDate { get; set; }
    }
}
