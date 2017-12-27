using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WReCommerce.Common.Enums;

namespace WReCommerce.Data.Models.Product
{
    public class Product
    {
        // Props
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DefaultValue(0)]
        public int ProductMembershipValue { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }

        [DefaultValue(0)]
        public decimal Weight { get; set; }

        public RefProductCategory ProductCategory { get; set; }

        public RefProductForm ProductForm { get; set; }

        //// Inverse Relationships
        //public int ProductTypeId { get; set; }
        //public RefProductType ProductType { get; set; }

    }
}