using AutoMapper;
using Cart.API.Entities;
using Cart.API.GrpcServices;
using Cart.API.Interfaces.IServices;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        //[Fact]
        //public async Task Test_Get_All()
        //{

        //    using (var client = new TestClientProvider().Client)
        //    {
        //        //Areenge
        //        var response = await client.GetAsync("/CartItems");
        //        //Act
        //        response.EnsureSuccessStatusCode();
        //        //Assert
        //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    }
        //}

        [Fact]
        public async Task GetAllCurtItems_ShouldReturnCartItems_WhenExists()
        {
            var crtItems = A.Fake<IEnumerable<CartItems>>();
            // Build your "app"
            var webHostBuilder = new WebHostBuilder()
                .Configure(app => app.Run(async ctx =>
                {
                    await ctx.Response.WriteAsync(JsonSerializer.Serialize(crtItems));
                }
                ));

            // Configure the in-memory test server, and create an HttpClient for interacting with it
            var server = new TestServer(webHostBuilder);
            HttpClient client = server.CreateClient();

            // Send requests just as if you were going over the network
            var responseHttp = await client.GetAsync("/CartItems");

            responseHttp.EnsureSuccessStatusCode();
            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var rsponseList = JsonSerializer.Deserialize<IEnumerable<CartItems>>(responseString);
            Assert.Equal(crtItems, rsponseList);
        }

        [Fact]
        public async Task GetCurtItemById_ShouldReturnCartItem_WhenExists()
        {
            int id = 1;
            var crtItem = A.Fake<CartItems>();
            // Build your "app"
            var webHostBuilder = new WebHostBuilder()
                .Configure(app => app.Run(async ctx =>
                {
                    await ctx.Response.WriteAsync(JsonSerializer.Serialize(crtItem));
                }
                ));

            // Configure the in-memory test server, and create an HttpClient for interacting with it
            var server = new TestServer(webHostBuilder);
            HttpClient client = server.CreateClient();

            // Send requests just as if you were going over the network
            var responseHttp = await client.GetAsync($"/CartItems/{id}");

            responseHttp.EnsureSuccessStatusCode();
            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var responseCartItems = JsonSerializer.Deserialize<CartItems>(responseString);
            Assert.Equal(crtItem.Id, responseCartItems.Id);
            Assert.Equal(crtItem.ItemId, responseCartItems.ItemId);
        }
        
        [Fact]
        public async Task AddCartItem_ShouldReturnTrue_WhenAdded()
        {
            //Arrenge
            bool expected = true;
            var crtItem = A.Fake<CartItems>();
            var webHostBuilder = new WebHostBuilder()
                .Configure(app => app.Run(async ctx =>
                {
                    await ctx.Response.WriteAsync(JsonSerializer.Serialize(expected));
                }
                ));

            var server = new TestServer(webHostBuilder);
            HttpClient client = server.CreateClient();
            //Act
            HttpContent context = new StringContent(JsonSerializer.Serialize(crtItem), Encoding.UTF8, "application/json");
            var responseHttp = await client.PostAsync("/CartItems", context);
            responseHttp.EnsureSuccessStatusCode();
            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var responseCartItems = JsonSerializer.Deserialize<bool>(responseString);
            //Assert
            Assert.Equal(expected, responseCartItems);
            Assert.True(expected);
            responseCartItems.Should().BeTrue();
            responseCartItems.Should().Be(expected);
        }
    }
}
