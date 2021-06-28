using Eshop.Domain.DomainModels;
using EShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string ownerId { get; set; }

        public EShopApplicationUser owner { get; set; }
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
    }
}
