using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
//using System.Web.Optimization;
using System.Web.Routing;


//namespace ConsoleApplication4
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var plainTextSecurityKey = "e0bf3334-e6dd-486a-92d4-d4ea18d6b200";
//            var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
//            var signingCredentials = new SigningCredentials(signingKey,
//                SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

//            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
//            {
//                new Claim(ClaimTypes.NameIdentifier, "myemail@myprovider.com"),
//                new Claim(ClaimTypes.Role, "Administrator"),
//            }, "Custom");

//            var securityTokenDescriptor = new SecurityTokenDescriptor()
//            {
//                AppliesToAddress = "http://my.website.com",
//                TokenIssuerName = "http://my.tokenissuer.com",
//                Subject = claimsIdentity,
//                SigningCredentials = signingCredentials,
//            };
//            var idtoken = "eyJraWQiOiJ7XCJwcm92aWRlcl90eXBlXCI6XCJkYlwiLFwiYWxpYXNcIjpcImJpbmRpZC1vaWRjLWp3dC1zaWduaW5nLWtleVwiLFwidHlwZVwiOlwibG9jYWxcIixcInZlcnNpb25cIjpcImF1dG8tZ2VuZXJhdGVkX2JpbmRpZFwifSIsInR5cCI6IkpXVCIsImFsZyI6IlJTMjU2In0.eyJhdF9oYXNoIjoibmZNZzZ5UmdXeFQ3Q0VGZ0dwZjV6QSIsInN1YiI6Ijk2NWYyMzBiLTdjNTEtNDhkOC1iZjVmLTZmNzUzZjIyMDRhMiIsIm9wIjoiaWQiLCJ2ZXIiOiIwIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsImRzaWQiOiI4ZDUyMTVhMi00M2I3LTRkZTMtOWE2YS01MWExYjVlNjI1ZjUiLCJhbXIiOlsidHMuYmluZF9pZC5hbWEiLCJ0cy5iaW5kX2lkLm1mY2EiXSwiaXNzIjoiaHR0cHM6XC9cL3NpZ25pbi5iaW5kaWQtc2FuZGJveC5pbyIsInBpZCI6ImlkcF9pbml0IiwicGFyYW1zIjp7fSwiYXVkIjoiNjQwOTFmMjQuOTViMjY4ZjIuZGVtb19mZDk5Yjk1ZmIxMzVlNjY5LmJpbmRpZC5pbyIsImF1dGhfdGltZSI6MTYzNDEzNjQ2MiwiZXhwIjoxNjM0MjIyOTYzLCJlbWFpbF9sYXN0X3VwZGF0ZSI6Ik92ZXIgMjggZGF5cyBhZ28iLCJiaW5kaWRfaW5mbyI6eyJhdXRoZW50aWNhdGluZ19kZXZpY2UiOnsiYnJvd3Nlcl90eXBlIjoiTW9iaWxlIFNhZmFyaSIsIm9zX3R5cGUiOiJpT1MiLCJvc192ZXJzaW9uIjoiMTQuNiIsImJyb3dzZXJfdmVyc2lvbiI6IjE0LjEuMSJ9LCJjYXBwX2ZpcnN0X2xvZ2luX2Zyb21fYXV0aGVudGljYXRpbmdfZGV2aWNlIjoxNjM0MTM2NDU4LCJjYXBwX2ZpcnN0X2xvZ2luIjoxNjM0MTM2NDYwLCJvcmlnaW5hdGluZ19kZXZpY2UiOnsiYnJvd3Nlcl90eXBlIjoiQ2hyb21lIiwib3NfdHlwZSI6IldpbmRvd3MiLCJvc192ZXJzaW9uIjoiMTAiLCJicm93c2VyX3ZlcnNpb24iOiI5NC4wLjQ2MDYuODEifX0sImlhdCI6MTYzNDEzNjU2MywiZW1haWwiOiJyYXZpdEB0cmFuc21pdHNlY3VyaXR5LmNvbSIsImp0aSI6IjUxOTQzN2I2LWQ3NDQtNGE1ZS04MjJmLTViMzcwNGUxMjg4MiJ9.M6u2u4cXxYqsJyRO5hKdkm0kUSb2-Riemx4gDqqE3jA2Xml2aqoRAK_tcOS_z4Oe5Ii9drxGPOWMdCpSFokLdq2yVTGeg1e5KOITiOtd2hvHEvfQY-d5bNEasOQZt7jk_8TycL8esXwAuGHSXBvIZyefLjyNHvGT0AmceheEyVsuALc2Fof_lQJ2xbKQmLiszjoUMFf6Uf97YAV27ICZjgvTShOLvIbcadCdtiwnr1D4Q95uo5lGqdHylk9-n1EhJdxOHgQ-xk84cDcCHdrk-vfpPOyA3eOCPh7TP2YGfOjIvq6Cj_G-N0BOiL4tbq0926qJIc9yo6vm4DJ_h_ilVA";

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
//            var plainToken = tokenHandler.CreateToken(idtoken);

//            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

//            Console.WriteLine(plainToken.ToString());
//            Console.WriteLine(signedAndEncodedToken);
//            Console.ReadLine();

//            var tokenValidationParameters = new TokenValidationParameters()
//            {
//                ValidAudiences = new string[]
//                {
//                    "http://my.website.com",
//                    "http://my.otherwebsite.com"
//                },
//                ValidIssuers = new string[]
//                {
//                    "http://my.tokenissuer.com",
//                    "http://my.othertokenissuer.com"
//                },
//                IssuerSigningKey = signingKey
//            };

//            SecurityToken validatedToken;
//            tokenHandler.ValidateToken(signedAndEncodedToken,
//                tokenValidationParameters, out validatedToken);

//            Console.WriteLine(validatedToken.ToString());
//            Console.ReadLine();
//        }
//    }
//}

namespace TodoListService_ManualJwt
{
    class Program : DelegatingHandler
    {
        private object _clientId;

        public object _tenant { get; private set; }
        public object _audience { get; private set; }
        public object _authority { get; private set; }
        private ISecurityTokenValidator _tokenValidator;

        async  Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // For debugging/development purposes, one can enable additional detail in exceptions by setting IdentityModelEventSource.ShowPII to true.
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

                // check if there is a jwt in the authorization header, return 'Unauthorized' error if the token is null.
                if (request.Headers.Authorization == null || request.Headers.Authorization.Parameter == null)
                    return BuildResponseErrorMessage(HttpStatusCode.Unauthorized);

                // Pull OIDC discovery document from Azure AD. For example, the tenant-independent version of the document is located
                // at https://login.microsoftonline.com/common/.well-known/openid-configuration.
                OpenIdConnectConfiguration config = null;
                try
                {
                    config = await GetConfigurationManager().GetConfigurationAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
#if DEBUG
                    return BuildResponseErrorMessage(HttpStatusCode.InternalServerError, ex.Message);
#else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
#endif
                }

                // You can get a list of issuers for the various Azure AD deployments (global & sovereign) from the following endpoint
                //https://login.microsoftonline.com/common/discovery/instance?authorization_endpoint=https://login.microsoftonline.com/common/oauth2/v2.0/authorize&api-version=1.1;

                IList<string> validissuers = new List<string>()
            {
                $"https://login.microsoftonline.com/{_tenant}/",
                $"https://login.microsoftonline.com/{_tenant}/v2.0",
                $"https://login.windows.net/{_tenant}/",
                $"https://login.microsoft.com/{_tenant}/",
                $"https://sts.windows.net/{_tenant}/"
            };

            // Initialize the token validation parameters
            object[] vs = new[] { _audience, _clientId };
            TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    // App Id URI and AppId of this service application are both valid audiences.
                    ValidAudiences = (IEnumerable<string>)vs,

                    // Support Azure AD V1 and V2 endpoints.
                    ValidIssuers = validissuers,
                    IssuerSigningKeys = config.SigningKeys

                    // Please inspect TokenValidationParameters class for a lot more validation parameters.
                };

                try
                {
                    // Validate token.
                    SecurityToken securityToken;
                    var claimsPrincipal = _tokenValidator.ValidateToken(request.Headers.Authorization.Parameter, validationParameters, out securityToken);

#pragma warning disable 1998
                    // This check is required to ensure that the Web API only accepts tokens from tenants where it has been consented to and provisioned.
                    if (!claimsPrincipal.Claims.Any(x => x.Type == ClaimConstants.ScopeClaimType)
                        && !claimsPrincipal.Claims.Any(y => y.Type == ClaimConstants.ScpClaimType)
                        && !claimsPrincipal.Claims.Any(y => y.Type == ClaimConstants.RolesClaimType))
                    {
#if DEBUG
                        return BuildResponseErrorMessage(HttpStatusCode.Forbidden, "Neither 'scope' or 'roles' claim was found in the bearer token.");
#else
                    return BuildResponseErrorMessage(HttpStatusCode.Forbidden);
#endif
                    }
#pragma warning restore 1998

                    // Set the ClaimsPrincipal on the current thread.
                    Thread.CurrentPrincipal = claimsPrincipal;

                    // Set the ClaimsPrincipal on HttpContext.Current if the app is running in web hosted environment.
                    if (HttpContext.Current != null)
                        HttpContext.Current.User = claimsPrincipal;

                    // If the token is scoped, verify that required permission is set in the scope claim.
                    // This could be done later at the controller level as well
                    return ClaimsPrincipal.Current.FindFirst(ClaimConstants.ScopeClaimType).Value != ClaimConstants.ScopeClaimValue
                        ? BuildResponseErrorMessage(HttpStatusCode.Forbidden)
                        : await base.SendAsync(request, cancellationToken);
                }
                catch (SecurityTokenValidationException stex)
                {
#if DEBUG
                    return BuildResponseErrorMessage(HttpStatusCode.Unauthorized, stex.Message);
#else
                return BuildResponseErrorMessage(HttpStatusCode.Unauthorized);
#endif
                }
                catch (Exception ex)
                {
#if DEBUG
                    return BuildResponseErrorMessage(HttpStatusCode.InternalServerError, ex.Message);
#else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
#endif
                }
            }

            private HttpResponseMessage BuildResponseErrorMessage(HttpStatusCode statusCode, string error_description = "")
            {
                var response = new HttpResponseMessage(statusCode);

                // The Scheme should be "Bearer", authorization_uri should point to the tenant url and resource_id should point to the audience.
                response.Headers.WwwAuthenticate.Add(
                    new AuthenticationHeaderValue("Bearer", "authorization_uri=\"" + _authority + "\"" + "," + "resource_id=" + _audience + $",error_description={error_description}"));
                return response;
            }

            /// <summary>
            /// The ConfigurationManager class holds properties to control the metadata refresh interval. 
            /// For more details, https://docs.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.protocols.configurationmanager-1?view=azure-dotnet
            /// </summary>
            /// <returns></returns>
            private ConfigurationManager<OpenIdConnectConfiguration> GetConfigurationManager() =>
                new ConfigurationManager<OpenIdConnectConfiguration>($"{_authority}/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());

        private static void Main(string[] args) => Console.ReadLine();
    }

        public static class ClaimConstants
        {
            public const string Name = "name";
            public const string ObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";
            public const string Oid = "oid";
            public const string PreferredUserName = "preferred_username";
            public const string TenantId = "http://schemas.microsoft.com/identity/claims/tenantid";
            public const string Tid = "tid";
            public const string ScopeClaimType = "http://schemas.microsoft.com/identity/claims/scope";
            public const string ScpClaimType = "scp";
            public const string RolesClaimType = "roles";

            public const string ScopeClaimValue = "access_as_user";


    }


}
