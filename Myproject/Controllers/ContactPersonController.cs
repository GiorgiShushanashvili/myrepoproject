using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Myproject.Services;
using Myproject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Myproject.Controllers
{
    [Route("api/controller")]
    public class ContactPersonController : Controller
    {
        private readonly ILogger<ContactPersonController> _logger;
        private readonly IContactPersonInterface _service;
        public ContactPersonController(IContactPersonInterface service,ILogger<ContactPersonController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("get/contactperson")]
        public async Task<IActionResult> GetContactPerson(int id)
        {
            try
            {
                var person = await _service.Find(id);
                return View(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("get/contactpersons")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                List<ContactPerson> persons = await _service.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("add/newcontact")]
        public async Task<IActionResult> AddNewContact(ContactPerson contactPerson)
        {
            try
            {
                var person = await _service.AddContactPerson(contactPerson);
                return Ok(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("update/contactperson")]
        public async Task<IActionResult> UpdateContactPerson(ContactPerson person, int id)
        {
            try
            {
                await _service.Update(person, id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("delete/contactperson")]
        public async Task<IActionResult> DeleteContactPerson(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
        
    }
}

