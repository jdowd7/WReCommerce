using System.ComponentModel.DataAnnotations;
using WReCommerce.Common.Enums;

namespace WReCommerce.Data.Models.Address.BaseEntities
{
    public abstract class AddressBase
    {
        [Required]
        [DataType(DataType.Text)]
        public string Street1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Street2 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required]
        public RefState State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public int Zip { get; set; }
    }
}
