using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FFSilverlight.Web.RestServices.Common;
using System.ServiceModel;
using System.ServiceModel.Web;
using Microsoft.Http;
using FFSilverlight.Web.Common;
using FFF.Entity.Family;
using System.ServiceModel.Activation;

namespace FFSilverlight.Web.RestServices.Authentication
{
    /// <summary>
    /// Login Authenticate Service
    /// </summary>
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LoginAuthenticateService:BaseRestfulService
    {
        [WebGet(UriTemplate="",ResponseFormat=WebMessageFormat.Json)]
        public override string Alert()
        {
            return "Login Authenticate Service";
        }

        [WebGet(UriTemplate = "AA?logid={id}", ResponseFormat = WebMessageFormat.Json)]
        public string HelloWorld(string id)
        {
            return id + "=Hello";
        }

        /// <summary>
        /// Show User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "Login?logid={id}", Method = "POST",RequestFormat=WebMessageFormat.Json,ResponseFormat=WebMessageFormat.Json)]
        public string ShowUser(string id, Person person)
        {
            return id + person.AccountID;
        }

        [WebInvoke(UriTemplate = "Hello?logid={id}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string ShowUser2(string id,string name)
        {
            return name+" Come Here"+id;
        }
    }
}