using Cart.API.Interfaces.IRpositories;
using Cart.API.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Carts = Cart.API.Entities.Cart;

namespace Cart.Tests
{
    public class CartServiceTests
    {
        private readonly CartService _cartServiceMock;
        private readonly Mock<ICartRepository> _cartRepostitoryMock = new Mock<ICartRepository>();

        public CartServiceTests()
        {
            _cartServiceMock = new CartService(_cartRepostitoryMock.Object);
        }

        [Fact]
        public async Task GetAllCartsAsync_ReturnsCarts()
        {
            //Arrange
            var cartList = new List<Carts>() {
            new Carts() { Id = 1,CustomerId=1,TotalPrice=200},
            new Carts() { Id = 2,CustomerId=7,TotalPrice=389 },
            new Carts() { Id = 3,CustomerId=4,TotalPrice=2546 },
            };
            _cartRepostitoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(cartList);
            //Act
            var carts = await _cartServiceMock.GetAllCartsAsync();
            //Assert
            Assert.Equal(cartList, carts);
        }
        
        [Fact]
        public async Task GetCartByCustomerIdAsync_ReturnsCar()
        {
            //Arrange
            int customerId = 2;
            var cart = new Carts() { Id = 1, CustomerId = 2, TotalPrice = 200 };
            _cartRepostitoryMock.Setup(x => x.GetCartByCustomerIdAsync(customerId)).ReturnsAsync(cart);
            //Act
            var carts = await _cartServiceMock.GetCartByCustomerIdAsync(customerId);
            //Assert
            Assert.Equal(cart, carts);
        }
        
        [Fact]
        public async Task GetCartByIdAsync_ReturnsTrue()
        {
            //Arrange
            int id = 1;
            var cart = new Carts() { Id = 1, CustomerId = 1, TotalPrice = 200 };
            _cartRepostitoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(cart);
            //Act
            var cartRes = await _cartServiceMock.GetCartByIdAsync(id);
            //Assert
            Assert.Equal(cart, cartRes);
        }
        
        [Fact]
        public async Task AddCartAsync_ReturnsTrue()
        {
            //Arrange
            bool expected = true;
            var cart = new Carts() { Id = 1, CustomerId = 1, TotalPrice = 200 };
            _cartRepostitoryMock.Setup(x => x.AddAsync(cart)).ReturnsAsync(expected);
            //Act
            var cartRes = await _cartServiceMock.AddCartAsync(cart);
            //Assert
            Assert.Equal(expected,cartRes);
            Assert.True(cartRes);
        }
        
        [Fact]
        public async Task UpdateCartAsync_ReturnsTrue()
        {
            //Arrange
            bool expected = true;
            var cart = new Carts() { Id = 1, CustomerId = 1, TotalPrice = 200 };
            _cartRepostitoryMock.Setup(x => x.UpdateAsync(cart)).ReturnsAsync(expected);
            //Act
            var cartRes = await _cartServiceMock.UpdateCartAsync(cart);
            //Assert
            
            Assert.Equal(expected, cartRes);
            Assert.True(cartRes);
            //Fluent Assertion
            cartRes.Should().Be(expected);
        }

        [Fact]
        public async Task DeleteCartAsync_ReturnsTrue()
        {
            //Arrange
            int id = 1;
            bool expected = true;
            _cartRepostitoryMock.Setup(x => x.DeleteAsync(id)).ReturnsAsync(expected);
            //Act
            var cartRes = await _cartServiceMock.DeleteCartAsync(id);
            //Assert
            Assert.Equal(expected, cartRes);
        }
    }
}
