namespace MongoLabSurveyor.Model
{
    using System.Collections.Generic;

    public class MongoLabDB
    {
        public string Name { get; set; }

        public DbStatsResponse DbStats { get; set;}
       
    }
}
