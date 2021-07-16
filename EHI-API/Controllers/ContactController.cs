using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EHI_API.Models;
using System.Data;
using EHI_API.Db;
namespace EHI_API.Controllers
{
    public class ContactController : ApiController
    {
        [HttpPost]
        public bool AddContact()
        {
            return true;
            //write insert logic  

        }
        [HttpGet]
        public List<DataRow> GetContacts()
        {
            DatabaseManager db = new DatabaseManager();
            DataTable dt = db.getList();
            List<DataRow> list = new List<DataRow>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr);
            }
            return list;
        }
        [HttpDelete]
        public string DeleteContact(string id)
        {

            return "Employee details deleted having Id " + id;

        }
        [HttpPut]
        public string UpdateContact(string Name, String Id)
        {
            return "Employee details Updated with Name " + Name + " and Id " + Id;

        }  
    }
}
