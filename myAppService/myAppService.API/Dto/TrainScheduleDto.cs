using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using myAppService.API.models;

namespace myAppService.API.Dto
{
    public class TrainScheduleDto
    {
        public int Id { get; set; }       

        public String   ArrivalTime {get;set;}
       
        public String  DepartureTime {get;set;}

        public int TrainId {get; set;}
        
    }
}