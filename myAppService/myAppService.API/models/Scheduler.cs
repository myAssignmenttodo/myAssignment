using System;
using System.ComponentModel.DataAnnotations;

namespace myAppService.API.models
{
    public class Scheduler
    {    
        public int Id { get; set; }         

        [Required]
        public string  ArrivalTime {get;set;}
        [Required]
        public string  DepartureTime {get;set;}
       
        public int TrainId {get; set;}
       
        public Train train {get;set;}

    }
}