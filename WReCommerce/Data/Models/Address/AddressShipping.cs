using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WReCommerce.Data.Models.Address
{
    public class AddressShipping
    {
        // Props
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateUpdated { get; set; }

        // Inverse Relationships
        public int UserprofileId { get; set; }
        public Userprofile.Userprofile Userprofile { get; set; }
    }
}
