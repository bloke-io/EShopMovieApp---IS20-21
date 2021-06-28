using Eshop.Domain.DomainModels;
using EShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string userId { get; set; }
        public EShopApplicationUser User { get; set; }

        public virtual IEnumerable<TicketInOrder> Tickets { get; set; }
    }
}