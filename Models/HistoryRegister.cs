using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EntityFramework.Models
{
    public class HistoryRegister
    {
        [Key]
        public int HistoryRegisterId { get; set; }
        public History History { get; set; } //obs: many Register are associated with one History
        public DateTime WatchDate { get; set; }
        public TimeSpan StopTime { get; set; }
        public Movie Movie { get; set; } //obs: many Register are associated with one Movie

    }
}