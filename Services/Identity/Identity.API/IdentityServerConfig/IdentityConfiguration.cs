using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
/*using ApiResource = IdentityServer4.EntityFramework.Entities.ApiResource;
using ApiScope = IdentityServer4.EntityFramework.Entities.ApiScope;
using IdentityResource = IdentityServer4.EntityFramework.Entities.IdentityResource;
using Client = IdentityServer4.EntityFramework.Entities.Client;
using Secret = IdentityServer4.EntityFramework.Entities.Secret;*/
using ApiResource = IdentityServer4.Models.ApiResource;
using ApiScope = IdentityServer4.Models.ApiScope;
using Client = IdentityServer4.Models.Client;
using IdentityResource = IdentityServer4.Models.IdentityResource;
using Secret = IdentityServer4.Models.Secret;

namespace Identity.API.IdentityServerConfig
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "123",
                    Username = "Andre",
                    Password = "Andre",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Andre Voronka"),
                        new Claim(JwtClaimTypes.GivenName, "Andre"),
                        new Claim(JwtClaimTypes.FamilyName, "Voronka"),
                        new Claim(JwtClaimTypes.WebSite, "http://testwebsite.com"),
                    }
                }
            };
        }
    

        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new ApiScope[]
            {
                    new ApiScope("apiread"),
                    new ApiScope("apiwrite"),
            };
        }

        public static IEnumerable<ApiResource> ApiResources() { 
             return new ApiResource[]
            {
                new ApiResource("Cart.API")
                {
                    Scopes = new List<string> { "apiread", "apiwrite" },
                    ApiSecrets = new List<Secret> { new Secret("supersecret".Sha256()) }
                },
                
                new ApiResource("Catalog.API")
                {
                    Scopes = new List<string> { "apiread", "apiwrite" },
                    ApiSecrets = new List<Secret> { new Secret("supersecret".Sha256()) }
                },

                new ApiResource("Ordering.API")
                {
                    Scopes = new List<string> { "apiread", "apiwrite" },
                    ApiSecrets = new List<Secret> { new Secret("supersecret".Sha256()) }
                }
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "apiread", "apiwrite" }
                },
            };
        }

    }
}