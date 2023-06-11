using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Myproject.Services;
using Myproject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Myproject.Controllers
{
    [Route("api/controller")]
    public class BanksController : Controller
    {
        private readonly ILogger<BanksController> _logger;
        private readonly IBanksInterface _service;
        public BanksController(IBanksInterface service,ILogger<BanksController> logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("get/bank")]
        public async Task<IActionResult> GetBank(int id)
        {
            try
            {
                var bank = await _service.Find(id);
                if (bank == null)
                    return NotFound("The bank can't be found");
                return View(bank);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
           
        }

        [HttpPost("add/newbank")]
        public async Task<IActionResult> AddNewBank(Banks bank)
        {
            try
            {
                var newbank = await _service.AddBank(bank);
                if (newbank == null)
                    return null;
                return (IActionResult)Ok(newbank);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }        
        }

        [HttpGet("get/allbanks")]
        public async Task<IActionResult> GetAllBanks()
        {
            try
            {
                return(IActionResult) await _service.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("delete/bank")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok("bank is deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
           
        }

        [HttpPut("update/bank")]
        public async Task<IActionResult> UpdateBank(Banks bank, int id)
        {
            try
            {
                await _service.Update(bank, id);
                return Ok($"{bank} is updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
        
    }
}

