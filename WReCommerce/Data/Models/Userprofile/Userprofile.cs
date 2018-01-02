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
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "Exceeds max length.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        // Relationships
        public virtual ICollection<AddressBilling> BillingAddresses { get; set; }

        public virtual ICollection<AddressShipping> ShippingAddresses { get; set; }

        public virtual ICollection<PurchaseOrder.PurchaseOrder> PurchaseOrders { get; set; }

        public virtual ICollection<UserMembership> UserMemberships { get; set; }

    }
}