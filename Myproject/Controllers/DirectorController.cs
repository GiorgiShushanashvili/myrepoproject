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
    public class DirectorController : Controller
    {
        private readonly ILogger<DirectorController> _logger;
        private readonly IDirectorInterface _service;
        public DirectorController(IDirectorInterface service, ILogger<DirectorController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("get/director")]
        public async Task<IActionResult> GetDirector(int id)
        {
            try
            {
                var director = await _service.Find(id);
                return View(director);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("get/directors")]
        public async Task<IActionResult> GetAllDirectors()
        {
            try
            {
                List<Director> directors = await _service.GetAll();
                return Ok(directors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("add/newdirector")]
        public async Task<IActionResult> AddDirector(Director director)
        {
            try
            {
                var newdirector = await _service.AddDirector(director);
                return Ok(newdirector);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("update/director")]
        public async Task<IActionResult> UpdateDirector(Director director, int id)
        {
            try
            {
                await _service.Update(director, id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("delete/director")]
        public async Task<IActionResult> DeleteDirector(int id)
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

