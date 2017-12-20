using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WReCommerce.Data.Models.Address;

namespace WReCommerce.Data.Models.Userprofile
{
    public class Userprofile
    {
        // Props
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Exceeds max length.")]
        public int FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Exceeds max length.")]
        public int LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public int Email { get; set; }

        // Relationships
        public ICollection<AddressBilling> BillingAddresses { get; set; }

        public ICollection<AddressShipping> ShippingAddresses { get; set; }

        public ICollection<PurchaseOrder.PurchaseOrder> PurchaseOrders { get; set; }

        public ICollection<UserMembership> UserMemberships { get; set; }

    }
}