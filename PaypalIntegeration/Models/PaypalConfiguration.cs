using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaypalIntegeration.Models
{
    public static class PaypalConfiguration
    {
        //Variables for storing the clientID and clientSecret key
        public readonly static string ClientId;
        public readonly static string ClientSecret;
        //Constructor
        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
            //ClientId = "AfTCgMU7eNbbwyj61lo5AnVg34RqrAmPZe - MADQhOg6bdpaQg8YwgsIs1FbGtxGBlQLrnBuRS0QJdGS0";
            //ClientSecret = "EBccdXDhr3w2nGRajxHNEI5EIcWywoRUihZzy2SHPf7PBN27CE4pmJVfink2vB5wK6MP3xCQ87wb7fRQ";
        }
        // getting properties from the web.config
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}