using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WReCommerce.Data.Models.PurchaseOrder
{
    public class PurchaseOrderShipment
    {
        // Props
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue("")]
        public string TrackingNumber { get; set; }

        [DefaultValue("")]
        public string ShipmentStatus { get; set; } // be better as enum

        [DefaultValue(1)]
        [Range(0, 9999999999999, ErrorMessage = "Must be a positive number.")]
        public int Items { get; set; }

        [DefaultValue(0)]
        [Range(0, 9999999999999, ErrorMessage = "Must be a positive number.")]
        public decimal Weight { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateModified { get; set; }


        // Relationships

        // POShips can have multiple POLines
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        // Inverse Relationships
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

       

    }
}