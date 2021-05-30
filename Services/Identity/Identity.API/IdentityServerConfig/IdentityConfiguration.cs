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
        public static IEnumerable<Client> Clients()
        {
            return new Client[]
            {
                //Block 2:  MVC client using hybrid flow
                new Client
                {
                    ClientId = "webclient",
                    ClientName = "Web Client",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "identity.api","test.api" }
                },

                //Block 3: SPA client using Code flow
                new Client
                {
                    ClientId = "spaclient",
                    ClientName = "SPA Client",
                    ClientUri = "https://localhost:5003",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =
                    {
                        "https://localhost:5003/index.html",
                        "https://localhost:5003/callback.html"
                    },

                    PostLogoutRedirectUris = { "https://localhost:5003/index.html" },
                    AllowedCorsOrigins = { "https://localhost:5003" },

                    AllowedScopes = { "openid", "profile", "identity.api" ,"test.api" }
                },
                new Client
                {
                    ClientId = "identityClient",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "apiread", "apiwrite" }
                },
            };
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
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

        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new ApiScope[]
            {
                    new ApiScope("apiread"),
                    new ApiScope("apiwrite"),
                    new ApiScope("openid"),
                    new ApiScope("profile"),
                    new ApiScope("identity.api"),
                    new ApiScope("test.api")
            };
        }

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
    }
}