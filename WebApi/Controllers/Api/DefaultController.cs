using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Entity;
namespace WebApi.Controllers.Api
{
    [Authorize]
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("api/Users/GetUserlist")]
        public IEnumerable<user_master> GetUserlist()
        {
           using (WgsnEntities db=new WgsnEntities())
           {
               return db.user_master.ToList();
           }
        }

        [Route("api/Users/GetRolelist")]
        public IEnumerable<Role> GetRolelist()
        {
            List<Role> Roles = new List<Role>();
            Roles.Add(new Role("Super Admin", 1));
            Roles.Add(new Role("Admin", 2));
            Roles.Add(new Role("Agent", 3));
            return Roles;
        }
        [Route("api/Users/Agentlist/{id}")]
        public IEnumerable<Role> Agentlist(int id)
        {
            List<Role> Roles = new List<Role>();
            Roles.Add(new Role("Agent1", 1));
            Roles.Add(new Role("Agent2", 2));
            Roles.Add(new Role("Agent3", 3));
            return Roles;
        }
        [HttpPost]
        [Route("api/Users/AdUsers")]
        public Response AdUsers([FromBody]user_master user)
        {
            using (WgsnEntities db = new WgsnEntities())
            {
                //db.user_master.Add(user);
                //db.SaveChanges();

            }
            return new Response(true, "Success", user);
        }
        //// GET: api/Default/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }

        public class Response
        {
            bool IsSuccess = false;
            string Message;
            object ResponseData;

            public Response(bool status, string message, object data)
            {
                IsSuccess = status;
                Message = message;
                ResponseData = data;
            }
        }
        public class Role
        {
            public string RoleName { get; set; }
            public int RoleId { get; set; }
            public Role(string p1, int p2)
            {
                // TODO: Complete member initialization
                this.RoleName = p1;
                this.RoleId = p2;
            }
           
        }
    }
}
