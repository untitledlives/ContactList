using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Models;

#region ContactListController
namespace ContactList.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsContext _context;
        #endregion
        public ContactsController(ContactsContext context)
        {
            _context = context;
        }

        // GET: Contacts
        #region snippet_GetAll
        [HttpGet]
        public IEnumerable<Contact> Index()
        {
            return _context.Contacts.ToList();
        }

        // GET: Contacts/Details
        #region snippet_GetAll

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(int id)
        {
            var item = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        #endregion
        #endregion
        #region snippet_Create
        [HttpPost] //made edit from post to patch 12/20/2017 @11:35am
        public IActionResult Create([FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Contacts.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetContacts", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Contact item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var contactUpdate = _context.Contacts.FirstOrDefault(t => t.Id == id);
            if (contactUpdate == null)
            {
                return NotFound();
            }

            contactUpdate.LastName = item.LastName;
            contactUpdate.FirstMidName = item.FirstMidName;
            contactUpdate.BirthDate = item.BirthDate;
            contactUpdate.EmailAddress = item.EmailAddress;
            contactUpdate.PhoneNumber = item.PhoneNumber;
            contactUpdate.Company = item.Company;
            

            _context.Contacts.Update(contactUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Contacts.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion
    }

}