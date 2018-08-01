using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace myAppService.API.models
{
    public class Train
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string FromLocation { get; set; }

        [Required]
        public string ToLocation { get; set; }

         [Required]

        public DateTime  ScheduledDate {get;set;}

        public ICollection<Scheduler> lstScheduler {get;set;} = new List<Scheduler>();
    }
}