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
using Microsoft.AspNetCore.Mvc.ModelBinding;

// return Ok(); // Http status code 200
// return Created(); // Http status code 201
// return NoContent(); // Http status code 204
// return BadRequest(); // Http status code 400
// return Unauthorized(); // Http status code 401
// return Forbid(); // Http status code 403
// return NotFound(); // Http status code 404

namespace myAppService.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class ScheduleController
    {
        private readonly IDataRepo _repo;

        private readonly IMapper _mapper;

        public ScheduleController(IDataRepo repo, IMapper mapper)
        {
            _repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Scheduler>))]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Scheduler>> GetSchedulerList()
        {
            var trainSchedules = await _repo.GetScheduleList();
            var trainToReturn = _mapper.Map<IEnumerable<TrainScheduleDto>>(trainSchedules);
            return trainSchedules;
        }

        [HttpGet("{id}", Name = "GetScheduleList")]
        [ProducesResponseType(200, Type = typeof(Scheduler))]
        [ProducesResponseType(404)]
        public async Task<Scheduler> GetScheduleList(int id)
        {
            var trains = await _repo.GetScheduleDetails(id);
            return trains;
        }

        [HttpPost("Add")]
        [ProducesResponseType(201, Type = typeof(Scheduler))]
        [ProducesResponseType(400)]
        public void AddScheduleDetails([FromBody] Scheduler TrainScheduleDto)
        {

            _repo.Add<Scheduler>(TrainScheduleDto);
            _repo.SaveAll();

        }

        [HttpPut("Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Scheduler))]
        [ProducesResponseType(204)]
        public void UpdateSchediuleDetails([FromBody] Scheduler trainScheduleDto)
        {
            _repo.Update<Scheduler>(trainScheduleDto);
            _repo.SaveAll();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public void Delete(int id)
        {
            var Scheduler = _repo.GetScheduleDetails(id).Result;
            _repo.Delete<Scheduler>(Scheduler);
            _repo.SaveAll();

        }

    }
}