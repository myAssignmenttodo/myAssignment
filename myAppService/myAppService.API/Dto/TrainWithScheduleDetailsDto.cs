using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myAppService.API.Dto
{
    public class TrainWithScheduleDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime ScheduledDate { get; set; }
        public ICollection<TrainScheduleDto> lstScheduler { get; set; } = new List<TrainScheduleDto>();
    }
}