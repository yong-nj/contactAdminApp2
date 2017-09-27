using ContactAdminApp2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DAL;
using System.Reflection;


namespace ContactAdminApp2.Controllers
{
    // now all controller functions  call DataAccess Stored procedule class..
    public class ContactController : Controller
    {             

        public ActionResult GetContacts(int id=-1)
        {          

            DataTable table1 = DataAccess_SP.GetDataTable(id);
           // List<ContactVM> list =   ConvertDataTable<ContactVM>(table1);         

            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult
            {
                // Content = JsonConvert.SerializeObject(list, camelCaseFormatter),
                Content = JsonConvert.SerializeObject(table1, camelCaseFormatter),
                ContentType = "application/json"
            };
            return jsonResult;
            //return new HttpStatusCodeResult(404, "Our custom error message...");
        }

        public ActionResult SearchContacts(string searchText ="")
        {       
            DataTable table1 = DataAccess_SP.SearchDataTable(searchText);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult
            {              
                Content = JsonConvert.SerializeObject(table1, camelCaseFormatter),
                ContentType = "application/json"
            };
            return jsonResult;          
        }


        public ActionResult Create(ContactVM contact)
        {
            if (ModelState.IsValid)
            {
                contact.BirthDate = contact.BirthDate.Substring(0, 10);
                int success = DataAccess_SP.Insert(contact);
                return new HttpStatusCodeResult(HttpStatusCode.Created, "New contact added");
            }

            List<string> errors = new List<string>();
            errors.Add("Insert failed.");
            if (!ModelState.IsValidField("Email"))
                errors.Add("Email is not valid.");

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError,
                String.Join("  ", errors));
        }


        public ActionResult Update(ContactVM contact)
        {
            contact.BirthDate = contact.BirthDate.Substring(0, 10);
            if (ModelState.IsValid)
            {
              // int success =DataAccess.Update(contact);
                int success = DataAccess_SP.Update(contact);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Update success");
            }

            List<string> errors = new List<string>();
            errors.Add("Update failed.");
            if (!ModelState.IsValidField("Notes"))
                errors.Add("Notes must be at least 5 characters long.");

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError,
                String.Join("  ", errors));
        }


        //[HttpPost, ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int Id = id.GetValueOrDefault();
        
            int success = DataAccess_SP.Delete(Id);
            return new HttpStatusCodeResult(HttpStatusCode.Created, "Contact deleted");

          
        }

     

    }
}