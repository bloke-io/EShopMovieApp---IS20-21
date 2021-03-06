using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Repository.Interface;
using EShop.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Ticket> _productRepository;
        private readonly IRepository<TicketInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IRepository<Ticket> productRepository, ILogger<ProductService> logger, IRepository<TicketInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _logger = logger;
        }

        public bool AddToShoppingCart(AddToShoppingCardDto item, string userID)
        {

            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.TicketId != null && userShoppingCard != null)
            {
                var ticket = this.GetDetailsForProduct(item.TicketId);

                if (ticket != null)
                {
                    TicketInShoppingCart itemToAdd = new TicketInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Ticket = ticket,
                        TicketId = ticket.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Product was successfully added into ShoppingCart");
                    return true;
                }
                return false;
            }
            _logger.LogInformation("Something was wrong. ProductId or UserShoppingCard may be unaveliable!");
            return false;
        }

        public void CreateNewProduct(Ticket t)
        {
            this._productRepository.Insert(t);
        }

        public void DeleteProduct(Guid id)
        {
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public List<Ticket> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts was called!");
            return this._productRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }

        public AddToShoppingCardDto GetShoppingCartInfo(Guid? id)
        {
            var ticket = this.GetDetailsForProduct(id);
            AddToShoppingCardDto model = new AddToShoppingCardDto
            {
                SelectedTicket = ticket,
                TicketId = ticket.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingProduct(Ticket t)
        {
            this._productRepository.Update(t);
        }

        List<Ticket> IProductService.GetAllProducts()
        {
            return this._productRepository.GetAll().ToList();
        }

        Ticket IProductService.GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }
    }
}