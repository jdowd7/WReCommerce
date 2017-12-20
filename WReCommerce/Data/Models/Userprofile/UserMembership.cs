using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WReCommerce.Common.Enums;

namespace WReCommerce.Data.Models.Userprofile
{
    public class UserMembership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal MembershipInitial { get; set; }

        public decimal MembershipRemaining { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateModified { get; set; }

        public RefProductCategory MembershipCategory { get; set; }

        // Inverse Relationships
        public int UserProfileId { get; set; }
        public Userprofile Userprofile { get; set; }

        public int ProductId { get; set; }
        public Product.Product Product { get; set; }
        


    }
}
