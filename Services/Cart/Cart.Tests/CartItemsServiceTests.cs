using Cart.API.Entities;
using Cart.API.Helpers;
using Cart.API.Interfaces.IRpositories;
using Cart.API.Interfaces.IServices;
using Cart.API.Models;
using Cart.API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Cart.Tests
{
    public class CartItemsServiceTests
    {
        private readonly CartItemsService _cartItemsServiceMock;
        private readonly Mock<ICartItemsRepository> _cartRepostitoryMock = new Mock<ICartItemsRepository>();

        public CartItemsServiceTests()
        {
            _cartItemsServiceMock = new CartItemsService(_cartRepostitoryMock.Object);
        }
        [Fact]
        public async Task GetAllCartItemsAsync_ShouldReturnListOfCartItems_WhenCartItemsExists()
        {
            //Arrange
            var cartItemsList = new List<CartItems>() {
            new CartItems() { Amount = 2, CartId = 1, Id = 1, ItemId = 2 },
            new CartItems() { Amount = 3, CartId = 2, Id = 2, ItemId = 1 },
            new CartItems() { Amount = 4, CartId = 3, Id = 3, ItemId = 3 },
            };
            _cartRepostitoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(() => cartItemsList);
            //Act
            var cartItems = await _cartItemsServiceMock.GetAllCartItemsAsync();
            //Assert
            Assert.Equal( cartItemsList, cartItems);
            //Assert.Collection<CartItems>(cartItems, cartItems.Count());
        }

        [Fact]
        public async Task GetCartItemByIdAsync_ShoudReturnCartItem()
        {
            //Arrange
            int id = 1;
            var cartItem = new CartItems() { Amount = 2, CartId = 1, Id = 1, ItemId = 2 };
            _cartRepostitoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(() => cartItem);
            //Act
            var cartItemRes = await _cartItemsServiceMock.GetCartItemByIdAsync(id);
            //Assert
            Assert.Equal(cartItem , cartItemRes);
        }
        
        [Fact]
        public async Task AddCartItemAsync_ShouldReturnTrue_WhenCartItemsAdded()
        {
            //Arrange
            bool expected = true;
            var cartItem = new CartItems() { Amount = 2, CartId = 1, Id = 1, ItemId = 2 };
            _cartRepostitoryMock.Setup(x => x.AddAsync(cartItem)).ReturnsAsync(() => expected);
            //Act
            var cartItemRes = await _cartItemsServiceMock.AddCartItemAsync(cartItem);
            //Assert
            Assert.Equal(expected, cartItemRes);
            Assert.True(cartItemRes);
        }
        
        [Fact]
        public async Task UpdateCartItemAsync_ShouldReturnTrue_WhenCartItemsUpdated()
        {
            //Arrange
            bool expected = true;
            var cartItem = new CartItems() { Amount = 2, CartId = 1, Id = 1, ItemId = 2 };
            _cartRepostitoryMock.Setup(x => x.UpdateAsync(cartItem)).ReturnsAsync(() => expected);
            //Act
            var cartItemRes = await _cartItemsServiceMock.UpdateCartItemAsync(cartItem);
            //Assert
            Assert.Equal(expected , cartItemRes);
            Assert.True(cartItemRes);
        }
        
        [Fact]
        public async Task DeleteCartItemAsync_ShouldReturnTrue_WhenCartItemsDeleted()
        {
            //Arrange
            int id = 1;
            bool expected = true;
            var cartItem = new CartItems() { Amount = 2, CartId = 1, Id = 1, ItemId = 2 };
            _cartRepostitoryMock.Setup(x => x.DeleteAsync(id)).ReturnsAsync(() => expected);
            //Act
            var cartItemRes = await _cartItemsServiceMock.DeleteCartItemAsync(id);
            //Assert
            Assert.Equal(expected , cartItemRes);
            Assert.True(cartItemRes);
        }
        
        [Fact]
        public async Task GetAllCartItemsForCartAsync_ShouldReturnCartItemsList()
        {
            //Arrange
            int cartId = 1;
            var cartItems = new List<CartItems> {
            new CartItems() { Amount = 2, CartId = 1, Id = 1, ItemId = 23 },
            new CartItems() { Amount = 75, CartId = 4, Id = 2, ItemId = 87 },
            new CartItems() { Amount = 75, CartId = 4, Id = 3, ItemId = 223 },
            new CartItems() { Amount = 34, CartId = 2, Id = 4, ItemId = 234 },
            };
            _cartRepostitoryMock.Setup(x => x.GetAllCartItemsForCartAsync(cartId)).ReturnsAsync(() => cartItems);
            //Act
            var cartItemRes = await _cartItemsServiceMock.GetAllCartItemsForCartAsync(cartId);
            //Assert
            Assert.Equal(cartItems, cartItemRes);
            Assert.NotNull(cartItemRes);
        }
        
        [Fact]
        public async Task GetAllItemsPagination_ShouldReturnPagedList()
        {
            //Arrange
            int count = 2;
            int pageNumber = 2;
            int pageSize = 2;
            var ciparams = new CartItemsParameters() {PageNumber=1,PageSize=2 };
            var cartItemsList = new List<CartItems> {
            new CartItems() { Amount = 2, CartId = 1, Id = 1, ItemId = 23 },
            new CartItems() { Amount = 75, CartId = 4, Id = 2, ItemId = 87 },
            new CartItems() { Amount = 75, CartId = 4, Id = 3, ItemId = 223 },
            new CartItems() { Amount = 34, CartId = 2, Id = 4, ItemId = 234 },
            };
            var cartItems = new PagedList<CartItems>(cartItemsList, count,pageNumber,pageSize);
            _cartRepostitoryMock.Setup(x => x.GetAllItemsPagination(ciparams)).ReturnsAsync(() => cartItems);
            //Act
            var cartItemRes = await _cartItemsServiceMock.GetAllCartItemsPaginationAsync(ciparams);
            //Assert
            Assert.Equal(cartItems, cartItemRes);
            Assert.NotNull(cartItemRes);
        }
    }
}
