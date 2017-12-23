using WReCommerce.Common.DTO;
using WReCommerce.Domain.Business.Models.PurchaseOrder;

namespace WReCommerce.Core.Interfaces
{
    public interface IPurchaseOrderRequestService
    {
        PurchaseOrderRequest AddPurchaseOrderRequest(OrderRequest orderRequest);
    }
}