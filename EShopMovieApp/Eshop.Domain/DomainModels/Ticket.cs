using Eshop.Domain.DomainModels;
using EShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        [Required]
        public string TicketName { get; set; }
        [Required]
        public string MovieName { get; set; }

        public string Genre { get; set; }

        public DateTime dateValid { get; set; }

        public double Price { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public virtual ICollection<TicketInOrder> Orders { get; set; }

    }
}
