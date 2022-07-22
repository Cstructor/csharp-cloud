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
        public IActionResult GetSpecific(int id)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound(null);
            }

            return Ok(contact);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] Contact value)
        {
            // This will never happen, value is always instantiated
            //if (value == null)
            //{
            //    return BadRequest("Invalid Contact Object");
            //}

            if (string.IsNullOrEmpty(value.Name))
            {
                return BadRequest(
                    new ErrorResponse
                    {
                        Message = "Null or Empty Field",
                        Field = "Name"
                    }) ;
            }

            value.Id= currentId++;
            value.DateAdded = DateTime.Now;
            contacts.Add(value);

            // DON'T DO THIS: return Created("Http://loc/api/contacts/"+value.Id, value);

            return CreatedAtAction(
                nameof(GetSpecific), // which method
                new { id = value.Id }, // route id
                value // response body
                );
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact != null)
            {
                contact.Name = value.Name;
                contact.Phones = value.Phones;
                return Ok(contact);
            }

            return NotFound();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rowsDeleted = contacts.RemoveAll(t => t.Id == id);

            if (rowsDeleted == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
