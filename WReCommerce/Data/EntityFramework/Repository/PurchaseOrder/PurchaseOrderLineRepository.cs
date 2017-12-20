using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Data.EntityFramework.Repository.PurchaseOrder
{
    public class PurchaseOrderLineRepository : IPurchaseOrderLineRepository
    {
        private CommercePlatformContext _context { get; set; }

        public PurchaseOrderLineRepository(CommercePlatformContext context)
        {
            _context = context;
        }

        public PurchaseOrderLine Get(int purchaseOrderLineId)
        {
            throw new System.NotImplementedException();
        }

        public PurchaseOrderLine AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            throw new System.NotImplementedException();
        }

        public PurchaseOrderLine UpdatePurchaseOrderLine(int purchaseOrderLineId, PurchaseOrderLine purchaseOrderLine)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePurchaseOrderLine(int purchaseOrderLineId)
        {
            throw new System.NotImplementedException();
        }
    }
}