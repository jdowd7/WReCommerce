using WReCommerce.Core.Interfaces;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Core.Services
{
    public class PurchaseOrderLineService : IPurchaseOrderLineService
    {
        public IPurchaseOrderLineRepository PurchaseOrderLineRepository { get; set; }
        public PurchaseOrderLineService(IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
            PurchaseOrderLineRepository = purchaseOrderLineRepository;
        }

        public PurchaseOrderLine GetPurchaseOrderLine(int purchaseOrderLineId)
        {
            throw new System.NotImplementedException();
        }

        public PurchaseOrderLine AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            return PurchaseOrderLineRepository.AddPurchaseOrderLine(purchaseOrderLine);
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