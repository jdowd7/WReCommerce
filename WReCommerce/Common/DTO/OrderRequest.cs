using System.Collections.Generic;

namespace WReCommerce.Common.DTO
{
    public class OrderRequest
    {
        public int UserprofileId { get; set; }

        /// <summary>
        /// Order object, product Id(s) and quantities
        /// </summary>
        public Dictionary<int, int> ProductIds { get; set; }
    }
}