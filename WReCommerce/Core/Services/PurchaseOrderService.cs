using WReCommerce.Core.Interfaces;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Core.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        public IPurchaseOrderRepository _purchaseOrderRepository { get; set; }

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public PurchaseOrder GetPurchaseOrder(int purchaseOrderId)
        {
            return _purchaseOrderRepository.Get(purchaseOrderId);
        }

        public PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            throw new System.NotImplementedException();
        }

        public PurchaseOrder UpdatePurchaseOrder(int purchaseOrderId, PurchaseOrder purchaseOrder)
        {
            return _purchaseOrderRepository.UpdatePurchaseOrder(purchaseOrderId, purchaseOrder);
        }

        public bool DeletePurchaseOrder(int purchaseOrderId)
        {
            throw new System.NotImplementedException();
        }
    }
}