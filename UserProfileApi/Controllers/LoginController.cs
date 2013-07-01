using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace UserProfileApi.Controllers
{
    public class LoginController : ApiController
    {

        private Data.UserProfileContextDataContext userProfileContext = new Data.UserProfileContextDataContext();

        [HttpPost]
        public Models.UserResult Post(JObject data)
        {
            if (data != null)
            {
                dynamic json = data;
                Models.User loginInfo = json.ToObject<Models.User>();
                Models.User user = new Models.User();
                List<Data.Token> tokenList = new List<Data.Token>();

                Data.User userExists = userProfileContext.Users.Where(b => b.UserName == loginInfo.username && b.Password == loginInfo.password).FirstOrDefault();

                

                if (userExists != null)
                {
                    //clean tokens
                    tokenList = userProfileContext.Tokens.Where(b => b.IdUsuario == userExists.Id).ToList();
                    if (tokenList.Count > 0)
                    {
                        userProfileContext.Tokens.DeleteAllOnSubmit(tokenList);
                        userProfileContext.SubmitChanges();
                    }

                    //register new token
                    string strToken = Guid.NewGuid().ToString();
                    Data.Token token = new Data.Token();

                    token.Date = DateTime.Now;
                    token.IdUsuario = userExists.Id;
                    token.IdToken = strToken;

                    userProfileContext.Tokens.InsertOnSubmit(token);

                    userProfileContext.SubmitChanges();

                    return new Models.UserResult()
                    {
                        result = true,
                        token = strToken

                    };

                }
                else
                {
                    return new Models.UserResult()
                    {
                        result = false,
                        message = "Username or password does not exist."
                    };

                }
            }
            else
            {
                return new Models.UserResult()
                {
                    result = false,
                    message = "Username or password are missing."
                };
            }
        }
             

        [HttpGet]
        public Data.User GetDetailsUser(string idToken)
        {
            Data.User userDetail = new Data.User();
            Data.Token tokenDetail = new Data.Token();
            if (idToken != null)
            {

                tokenDetail = userProfileContext.Tokens.Where(b => b.IdToken == idToken).FirstOrDefault();
                if (tokenDetail != null)
                {
                    userDetail = userProfileContext.Users.Where(b => b.Id == tokenDetail.IdUsuario).FirstOrDefault();
                }                
            }
            return userDetail;
        }


        [HttpDelete]
        public Models.UserResult DeleteToken(string idToken)
        {
            Data.User userDetail = new Data.User();
            Data.Token token = new Data.Token();
            if (idToken != null)
            {

                token = userProfileContext.Tokens.Where(b => b.IdToken == idToken).FirstOrDefault();
                if (token != null)
                {

                    userProfileContext.Tokens.DeleteOnSubmit(token);
                    userProfileContext.SubmitChanges();

                
                return new Models.UserResult(){result = true };
                }
                else
                    return new Models.UserResult() { result = false };

            }
            else
            {
                return new Models.UserResult() { result = false };
            }
        }

    }
}
