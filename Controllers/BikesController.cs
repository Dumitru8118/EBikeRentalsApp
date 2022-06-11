using Dapper;
using EBikeRentalsApp.Data;
using EBikeRentalsApp.DbAccessLayer;
using EBikeRentalsApp.Models;
using EBikeRentalsApp.Repository.Bikes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BikesController : ControllerBase
    {
        //private readonly IBikeData _bikeData;

        private readonly IBikesRepository<BikeModel> _bikeRepository;
        //private readonly ILogger<BikesController> _logger;
        public BikesController(IBikesRepository<BikeModel> bikeRepository)
        {
            //_logger = logger;
            _bikeRepository = bikeRepository;
        }

        [HttpGet]
        [Route("GetBikes")]
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

        [HttpPost]
        [Route("AddBike")]
        public async Task<ActionResult> AddBike(BikeModel bike)
        {
            try 
            {
                var parameters = new DynamicParameters();
                parameters.Add("id", bike.id, DbType.String);
                parameters.Add("bikeTypes", bike.bikeTypes, DbType.String);
                parameters.Add("register_date", bike.register_date, DbType.String);

                await _bikeRepository.InsertBike(parameters);
                return Ok("201");
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        //public IActionResult Index()
        //{
        //    //return View();
        //}
    }
}
