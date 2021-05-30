using AutoMapper;
using Cart.API.GrpcServices;
using Cart.API.Interfaces.IServices;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cart.Tests.IntedrationTests
{
    public class CartItemsControllerTests
    {
        //private readonly DiscountGrpcService _discountGrpcService = A.Fake<DiscountGrpcService>();
        //private readonly ICartItemsService _cartItemsService = A.Fake<ICartItemsService>();
        //private readonly IRedisCacheService _cacheService = A.Fake<IRedisCacheService>();
        //private readonly IMapper _mapper = A.Fake<IMapper>();

        [Fact]
        public async Task Test_Get_All()
        {

            using (var client = new TestClientProvider().Client)
            {
                //Areenge
                var response = await client.GetAsync("/CartItems");
                //Act
                response.EnsureSuccessStatusCode();
                //Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
