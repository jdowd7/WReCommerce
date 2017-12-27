using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WReCommerce.Data.Models.PurchaseOrder
{
    public class PurchaseOrderLine
    {
        // Props
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue(1)]
        [Range(0, 9999999999999, ErrorMessage = "Must be a positive number.")]
        public int Quantity { get; set; }

        [DefaultValue(0)]
        [DataType(DataType.Currency)]
        [Range(0, 9999999999999, ErrorMessage = "Must be a positive number.")]
        public decimal Subtotal { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded{ get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateModified { get; set; }

        // Inverse Relationships

        // POLine can have 1 PO
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrders { get; set; }

        // POLine can have 1 Product
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }

        // POLine can have 1 POShip
        public int PurchaseOrderShipment { get; set; }
        public PurchaseOrderShipment PurchaePurchaseOrderShipment { get; set; }



    }
}
