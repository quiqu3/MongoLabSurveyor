using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLabSurveyor.Model
{
    public class MongoLabDB
    {
        public string Name { get; set; }

        public DbStatsResponse Collections { get; set; }
    }
}
