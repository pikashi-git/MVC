using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace 購物網站MVC_Demo.Security
{
    public class JwtService
    {
        public string GenerateJwtToken(string account, string role)
        {
            JwtObject jwtObject = new JwtObject
            {
                Account = account,
                Role = role,
                Expire = DateTime.Now.AddMinutes(Convert.ToInt32(WebConfigurationManager.AppSettings["expireMinutes"])).ToString()
            };
            var secretKey = WebConfigurationManager.AppSettings["secretKey"].ToString();
            var payload = jwtObject;
            var token = JWT.Encode(jwtObject, Encoding.UTF8.GetBytes(secretKey), JwsAlgorithm.HS512);
            return token;
        }
    }
}