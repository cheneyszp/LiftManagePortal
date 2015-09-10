using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiftManagePortal.Models
{
    public class StatusLog
    {
        public string StatusLogId { get; set; }
        public string DeviceId { get; set; }
        public string Status { get; set; }
        public string EventEnqueuedUtcTime { get; set; }

        public string CPUUsage { get; set; }

        public string DiskUsage { get; set; }

        public string MemoryUsage { get; set; }
    }
}