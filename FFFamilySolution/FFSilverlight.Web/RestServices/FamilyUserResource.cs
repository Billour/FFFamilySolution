using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Http;
using System.ServiceModel;
using System.ServiceModel.Web;
using FFF.Entity;
using FFF.Entity.Family;
using System.Json;


namespace FFSilverlight.Web.RestServices
{
    [ServiceContract]
    public class FamilyUserResource
    {
        [WebGet(UriTemplate = "{id}")]
        public string GetFamilyID(string id)
        {
            return "Hello World="+id;
        }

        //[WebGet(UriTemplate = "{id}")]
        //public Contact Get(string id, HttpResponseMessage response)
        //{
        //    var contact = this.repository.Get(int.Parse(id, CultureInfo.InvariantCulture));
        //    if (contact == null)
        //    {
        //        response.StatusCode = HttpStatusCode.NotFound;
        //        response.Content = HttpContent.Create("Contact not found");
        //    }

        //    return contact;
        //}

        //[WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        //public Contact Put(string id, Contact contact, HttpResponseMessage response)
        //{
        //    this.Get(id, response);
        //    this.repository.Update(contact);
        //    return contact;
        //}
    }
}