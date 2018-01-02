using System.Collections.Generic;
using FluentAssertions;
using WReCommerce.Core.Interfaces;
using WReCommerce.Core.Services;
using WReCommerce.Data.Models.PurchaseOrder;
using WReCommerce.Data.Models.Userprofile;
using WReCommerce.Test.Infrastructure;
using Xunit;

namespace WReCommerce.Test.Integration.Core.Services.PurchaseOrder
{
    public class PurchaseOrderLineShipmentTest : TestContainer
    {
        public IPurchaseOrderShipmentService PurchaseOrderShipmentService { get; set; }



        public PurchaseOrderLineShipmentTest()
        {
            PurchaseOrderShipmentService = Container.GetInstance<IPurchaseOrderShipmentService>();

        }

        [Fact]
        public void AddPurchaseOrderShipment_ValidPOS_ShouldReturnAddedPOS()
        {
            var pos = new PurchaseOrderShipment
            {
                PurchaseOrder = new Data.Models.PurchaseOrder.PurchaseOrder(),
                Items = 1,
                Weight = 1,
                ShipmentStatus = "Shipping",
                TrackingNumber = "Test",
                PurchaseOrderLines = new List<PurchaseOrderLine>()
            };

            var result = PurchaseOrderShipmentService.AddPurchaseOrderShipment(pos);
            result.Id.Should().BeGreaterThan(0);

        }
    }
}