using System.Collections.Generic;
using WReCommerce.Data.Models.Product;

namespace WReCommerce.Common.DTO
{
    public class OrderRequest
    {
        public int UserprofileId { get; set; }

        /// <summary>
        /// Order object, product Id(s) and quantities
        /// </summary>
        public Dictionary<Product, int> ProductIds { get; set; }
    }
}