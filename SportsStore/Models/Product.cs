using System.ComponentModel.DataAnnotations.Schema;

// Entity Framework - 3 ways: Code First, database first, model first. We'll do code first
namespace SportsStore.Models
{
    [Table("Products")]
    public class Product
    {
        // F i e l d s  &  P r o p e r t i e s

        public int     ProductId   { get; set; } //entity framework recognizes ProductId syntax as primary key

        public string  Name        { get; set; }

        public string  Description { get; set; }

        [Column(TypeName = "decimal(8,2)")]      // 8 total digits, two of those are decimals
        public decimal Price       { get; set; }

        public string  Category    { get; set; }
        // C o n s t r u c t o r s

        // M e t h o d s
    }
}
