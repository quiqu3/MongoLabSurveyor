namespace MongoLabSurveyor.Model
{
    using System.Collections.Generic;

    public class MongoLabDB
    {
        public string Name { get; set; }

        public List<Collection> Collections { get; set; }
    }
}
