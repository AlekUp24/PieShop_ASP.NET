using System.ComponentModel;
using System.Reflection.PortableExecutable;

namespace PieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? AllergyInformation { get; set; }
        public decimal Price {  get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailURL { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CatergoryId { get; set; }
        public Category Category { get; set; } = default!;
        

    }
}
 