using HelloWorldService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public static List<Contact> contacts = new List<Contact>();
        private static int currentId = 101;

        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return contacts;
        }

        // GET api/<ContactsController>/101
        [HttpGet("{id}")]
        public Contact GetSpecific(int id)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);
            
            return contact;
        }

        // POST api/<ContactsController>
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            value.Id= currentId++;
            value.DateAdded = DateTime.Now;
            contacts.Add(value);
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact value)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact != null)
            {
                contact.Name = value.Name;
                contact.Phones = value.Phones;
            }
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rowsDeleted = contacts.RemoveAll(t => t.Id == id);
        }
    }
}
