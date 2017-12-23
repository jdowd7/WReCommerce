using WReCommerce.Common.DTO;
using WReCommerce.Data.Models.PurchaseOrder;
using WReCommerce.Domain.Business.Models.PurchaseOrder;

namespace WReCommerce.Data.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrderRequestRepository
    {
        Models.PurchaseOrder.PurchaseOrder AddPurchaseOrder(Models.PurchaseOrder.PurchaseOrder purchaseOrder);

        PurchaseOrderLine AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
    }
}