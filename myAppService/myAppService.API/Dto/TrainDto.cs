using System;
using System.ComponentModel.DataAnnotations;

namespace myAppService.API.Dto
{
    public class TrainDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string FromLocation { get; set; }
        public String ToLocation { get; set; }

        public DateTime ScheduledDate { get; set; }

    }
}