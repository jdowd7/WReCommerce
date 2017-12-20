using WReCommerce.Data.Models.Address;

namespace WReCommerce.Data.Interfaces.Address
{
    public interface IAddressShippingRepository
    {
        AddressShipping Get(int addressId);
        AddressShipping AddBillingAddress(AddressShipping addressShipping);
        AddressShipping UpdateBillingAddress(int addressId, AddressShipping addressShipping);
        bool DeleteBillingAddress(int addressId);
    }
}