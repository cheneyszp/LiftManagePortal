using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LiftManagePortal.Models
{
    public class DeviceDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DeviceDBContext() : base("name=DeviceDBContext")
        {
        }

        public System.Data.Entity.DbSet<LiftManagePortal.Models.Device> Devices { get; set; }

        public System.Data.Entity.DbSet<LiftManagePortal.Models.StatusLog> StatusLogs { get; set; }

        public System.Data.Entity.DbSet<LiftManagePortal.Models.DeviceStatus> DeviceStatus { get; set; }
    }
}
