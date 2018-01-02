using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WReCommerce.Common.Enums;

namespace WReCommerce.Data.Models.PurchaseOrder
{
    public class PurchaseOrder
    {
        // Props
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue(0)]
        [Range(0, 9999999999999, ErrorMessage = "Must be a positive number.")]
        public decimal TotalShipping { get; set; }

        [DefaultValue(0)]
        [DataType(DataType.Currency)]
        [Range(0, 9999999999999, ErrorMessage = "Must be a positive number.")]
        public decimal TotalAmount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateUpdated { get; set; }

        // Relationships
        [DefaultValue(0)]
        public RefPurchaseOrderStatus RefPurchaseOrderStatus { get; set; }

        // PO can have many POLines
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        // PO can have many POShips (break order, etc.)
        public virtual ICollection<PurchaseOrderShipment> PurchaseOrderShipments { get; set; }

        // Inverse Relationships
        public int UserProfileId { get; set; }
        public virtual Userprofile.Userprofile Userprofile { get; set; }
    }
}