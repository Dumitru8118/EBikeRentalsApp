using Dapper;
using EBikeRentalsApp.DataAccessLayer.Models;
using EBikeRentalsApp.DataAccessLayer.Repository.Bikes;
using EBikeRentalsApp.DataAccessLayer.Repository;
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

        private readonly IGenericRepository<BikeModel> _genericRepository;

        //private readonly ILogger<BikesController> _logger;
        public BikesController(IBikesRepository<BikeModel> bikeRepository,
            IGenericRepository<BikeModel> genericRepository)
        {
            //_logger = logger;
            _genericRepository = genericRepository;
        }

        [HttpGet]
        [Route("GetBikes")]
        public async Task<ActionResult<string>> GetBikes()
        {
            try
            {
                var bikes = await _genericRepository.GetEntities("dbo.GetAll_Bikes");
                Console.WriteLine(bikes);
                return Ok(JsonConvert.SerializeObject(bikes));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        //("{id}")
        [HttpGet]
        [Route("GetBikeById/{id}")]
        public async Task<ActionResult<string>> GetBikeById(int id)
        {
            try
            {
                var bike = await _genericRepository.GetEntityById("dbo.sp_getBike", id);
                return Ok(JsonConvert.SerializeObject(bike));
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
                parameters.Add("bikeId", bike.id, DbType.String);
                parameters.Add("bikeTypeId", bike.bikeTypes, DbType.String);
                parameters.Add("register_date", bike.register_date, DbType.String);

                var spname = "dbo.sp_InsertBikes";

                await _genericRepository.AddEntity(bike, spname, parameters);
                return Ok("201");
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteBike")]
        public async Task<ActionResult> DeleteBike(BikeModel bike)
        {
            try
            {
                await _genericRepository.DeleteEntities("dbo.sp_DeleteBikes", bike.id);
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
