using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickClock.Models
{
    public class TickClockDatabaseSettings:ITickClockDatabaseSettings
    {
        public string TodosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ITickClockDatabaseSettings
    {
        public string TodosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
