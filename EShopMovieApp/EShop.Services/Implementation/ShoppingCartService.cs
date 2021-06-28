using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Repository.Interface;
using EShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepositorty;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TicketInOrder> _productInOrderRepository;
        private readonly IUserRepository _userRepository;
        //private readonly IRepository<EmailMessage> _mailRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<TicketInOrder> productInOrderRepository, IRepository<Order> orderRepositorty, IUserRepository userRepository)
        {
            _shoppingCartRepositorty = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepositorty;
            _productInOrderRepository = productInOrderRepository;
         //   _mailRepository = mailRepository;
        }

        public bool deleteProductFromShoppingCart(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                //Select * from Users Where Id LIKE userId

                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.TicketInShoppingCarts.Where(z => z.TicketId.Equals(id)).FirstOrDefault();

                userShoppingCart.TicketInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepositorty.Update(userShoppingCart);

                return true;
            }

            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggedInUser.UserCart;

            var AllProducts = userShoppingCart.TicketInShoppingCarts.ToList();

            var allProductPrice = AllProducts.Select(z => new
            {
                ProductPrice = z.Ticket.Price,
                Quanitity = z.Quantity
            }).ToList();

            double totalPrice = 0.0;


            foreach (var item in allProductPrice)
            {
                totalPrice += item.Quanitity * item.ProductPrice;
            }


            ShoppingCartDto scDto = new ShoppingCartDto
            {
                Tickets = AllProducts,
                TotalPrice = totalPrice
            };


            return scDto;

        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                //Select * from Users Where Id LIKE userId

                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

               // EmailMessage mail = new EmailMessage();
               // mail.MailTo = loggedInUser.Email;
               // mail.Subject = "Successfully created order";
               // mail.Status = false;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    userId = userId
                };

                this._orderRepository.Insert(order);

                List<TicketInOrder> productInOrders = new List<TicketInOrder>();

                var result = userShoppingCart.TicketInShoppingCarts.Select(z => new TicketInOrder
                {
                    Id = Guid.NewGuid(),
                    TicketId = z.Ticket.Id,
                    SelectedTicket = z.Ticket,
                    OrderId = order.Id,
                    UserOrder = order,
                    Quantity = z.Quantity
                }).ToList();

               // StringBuilder sb = new StringBuilder();

               // double totalPrice = 0.0;

              //  sb.AppendLine("Your order is completed. The order conains: ");

              /*  for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i - 1];

                    totalPrice += item.Quantity * item.SelectedTicket.Price;

                    sb.AppendLine(i.ToString() + ". " + item.SelectedTicket.TicketName + " with price of: " + item.SelectedTicket.Price + " and quantity of: " + item.Quantity);
                } */

               // sb.AppendLine("Total price: " + totalPrice.ToString());


              //  mail.Content = sb.ToString();


                productInOrders.AddRange(result);

                foreach (var item in productInOrders)
                {
                    this._productInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.TicketInShoppingCarts.Clear();

                this._userRepository.Update(loggedInUser);
                //this._mailRepository.Insert(mail);

                return true;
            } 
            return false;
        } 
    }
}