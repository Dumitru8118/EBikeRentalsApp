using EBikeRentalsApp.Data;
using EBikeRentalsApp.DbAccessLayer;
using EBikeRentalsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Controllers
{
    
    [ApiController]
    [Route("api/bikes")]
    public class BikesController : Controller
    {
        //private readonly IBikeData _bikeData;

        private readonly IGenericRepository<BikeModel> _bikeRepository;
        //private readonly ILogger<BikesController> _logger;
        public BikesController(IGenericRepository<BikeModel> bikeRepository)
        {
            //_logger = logger;
            _bikeRepository = bikeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetBikes()
        {
            try
            {
                var bikes = await _bikeRepository.GetBikes();
                Console.WriteLine(bikes);
                return Ok(JsonConvert.SerializeObject(bikes));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
