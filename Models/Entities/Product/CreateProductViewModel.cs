using System.ComponentModel.DataAnnotations;

namespace LojinhaDaPaulinha.Models.Entities.Product
{
    public class CreateProductViewModel : IInputViewModel
    {
        [Required(ErrorMessage = "A Name is required for the Product.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "A Category is required for the Product.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "A Price is required for the Product.")]
        public double Price { get; set; }

        public bool IsAvaliable { get; set; }
    }
}
