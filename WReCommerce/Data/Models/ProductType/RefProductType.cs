using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WReCommerce.Common.Enums;

namespace WReCommerce.Data.Models.ProductType
{
    public class RefProductType
    {
        // Props
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        // Inverse Relationships
        public RefProductForm ProductForm { get; set; }

        public RefProductCategory ProductCategory { get; set; }

    }
}