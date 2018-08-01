using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using myAppService.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myAppService.API.models;
using AutoMapper;
using myAppService.API.Dto;
using System.Net;



// return Ok(); // Http status code 200
// return Created(); // Http status code 201
// return NoContent(); // Http status code 204
// return BadRequest(); // Http status code 400
// return Unauthorized(); // Http status code 401
// return Forbid(); // Http status code 403
// return NotFound(); // Http status code 404

namespace myAppService.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]

    public class TrainController
    {
        private readonly IDataRepo _repo;

        public TrainController(IDataRepo repo,IMapper mapper)
        {            
            _repo = repo;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Train))]
        [ProducesResponseType(404)]
        public async Task<Train> GetTrainList(int id)
        {
            var trains = await _repo.GetTrainDetails(id);
            return trains;
            
        }
     

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Train>))]
        [ProducesResponseType(404)]
        public async Task<List<Train>> GetTrains()
        {
            var trains = await _repo.GetListOfTrains();
            return  trains;
        }

        
        [HttpGet]
        [Route("all")]  
        [ProducesResponseType(200, Type = typeof(List<Train>))]
        [ProducesResponseType(404)] 
         public async Task<List<Train>> GetAll()
        {
            var trains = await _repo.GetTrainSchedules();

            return trains;
        }

         [HttpPost("Add")]
         [ProducesResponseType(201, Type = typeof(Train))]
         [ProducesResponseType(400)] 
         public  void AddTrainDetails([FromBody] Train train)
        {      
             _repo.Add<Train>(train);     
            _repo.SaveAll();
            
         }

          [HttpPut("Update")]     
          [ProducesResponseType(400)] 
          [ProducesResponseType(200, Type = typeof(Train))]
          [ProducesResponseType(204)]

         public  void UpdateTrainDetails([FromBody] Train train)
        {            
             _repo.Update<Train>(train);
            _repo.SaveAll();
            
         }

         [HttpDelete("{id}")] 
          [ProducesResponseType(200)]
          [ProducesResponseType(204)]
         public  void Delete(int id)
        {      
            var train =  _repo.GetTrainDetails(id).Result;      
             _repo.Delete<Train>(train);
            _repo.SaveAll();
            
         }

    }
}