using WReCommerce.Data.Models.Address;

namespace WReCommerce.Data.Interfaces.Address
{
    public interface IAddressBillingRepository
    {
        AddressBilling GetBillingAddress(int addressId);
        AddressBilling AddBillingAddress(AddressBilling addressBilling);
        AddressBilling UpdateBillingAddress(int addressId, AddressBilling addressBilling);
        bool DeleteBillingAddress(int addressId);

    }
}