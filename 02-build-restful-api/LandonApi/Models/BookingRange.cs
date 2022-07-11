using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandonApi.Models
{
    public class BookingRange
    {
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set;}
    }
}
