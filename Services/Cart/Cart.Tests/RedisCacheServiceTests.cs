using Cart.API.Entities;
using Cart.API.Interfaces.IRpositories;
using Cart.API.Services;
using FakeItEasy;
using Moq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Cart.Tests
{
    public class RedisCacheServiceTests
    {
        private readonly RedisCacheService _cartRedisServiceMock;
        private readonly Mock<IConnectionMultiplexer> _cartMultiplexorMock = new Mock<IConnectionMultiplexer>();

        public RedisCacheServiceTests()
        {
            _cartRedisServiceMock = new RedisCacheService(_cartMultiplexorMock.Object);
        }

        //[Fact]
        //public async Task GetRecordAsync_ReturnsCarts()
        //{
        //    //Arrange
        //    string record = "CartItems1";
        //    int numberOfDummies = 5;
        //    var cartList = A.CollectionOfDummy<CartItems>(numberOfDummies).AsEnumerable();
        //    var conMult = A.Fake<IConnectionMultiplexer>();
        //    var db = A.Fake<IDatabase>(opt => opt.ConfigureFake(action => { 
        //        action.StringGetAsync(record); 
        //    }));
        //    A.CallTo(() => conMult.GetDatabase().StringGetAsync(new RedisKey(record))).ReturnsAsync(new RedisValue(JsonSerializer.Serialize(cartList)));
        //    //Act
        //    var carts = await _cartRedisServiceMock.GetRecordAsync<IEnumerable<CartItems>>(record);
        //    //Assert
        //    Assert.Equal(cartList, carts);
        //}

        //[Fact]
        //public async Task GetRecordAsync_ReturnsCarts()
        //{
        //    //Arrange
        //    string record = "CartItems1";
        //    var cartList = new List<CartItems>() {
        //    new CartItems() { Id = 1,Amount=21,CartId=2,ItemId=4},
        //    new CartItems() { Id = 2,Amount=34,CartId=4,ItemId=4},
        //    new CartItems() { Id = 3,Amount=45,CartId=2,ItemId=2},
        //    };
        //    _cartMultiplexorMock.Setup(x => x.GetDatabase().StringGetAsync(record)).ReturnsAsync(new RedisValue(JsonSerializer.Serialize(cartList)));
        //    //db.StringGetAsync(recordId)
        //    //Act
        //    var carts = await _cartRedisServiceMock.GetRecordAsync<IEnumerable<CartItems>>(record);
        //    //Assert
        //    Assert.Equal(cartList, carts);
        //}

        //[Fact]
        //public async Task SetRecordAsync_ReturnsCarts()
        //{
        //    //Arrange
        //    string record = "CartItems1";
        //    var cartList = new List<CartItems>() {
        //    new CartItems() { Id = 1,Amount=21,CartId=2,ItemId=4},
        //    new CartItems() { Id = 2,Amount=34,CartId=4,ItemId=4},
        //    new CartItems() { Id = 3,Amount=45,CartId=2,ItemId=2},
        //    };
        //    var _db = new Mock<IDatabase>();
        //    _cartMultiplexorMock.Setup(x => x.).Returns(_db);
        //    //db.StringGetAsync(recordId)
        //    //Act
        //    await _cartRedisServiceMock.SetRecordAsync<IEnumerable<CartItems>>(record, cartList);
        //    //Assert
        //    Assert.Equal(cartList, carts);
        //}
    }
}
