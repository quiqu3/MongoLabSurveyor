using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLabSurveyor.Model
{
    public class DbStatsResponse
    {
        public string serverUsed {get; set;}

        public int collections { get; set; }

        public int objects { get; set; }

        public float avgObjSize { get; set; }

        public int dataSize { get; set; }

        public int storageSize { get; set; }

        public int numExtents { get; set; }

        public int indexes { get; set; }

        public int indexSize { get; set; }

        public int fileSize { get; set; }

        public int nsSizeMB { get; set; }

           
            
        ////    "serverUsed" : "terminus10.mongolab.com/10.38.43.112:41167" , 
        ////"db" : "IdleBitMongoLab" , 
        //"collections" : 3 ,
        //"objects" : 9 ,
        //"avgObjSize" : 76.0 ,
        //"dataSize" : 0 ,
        //"storageSize" : 20 ,
        //"numExtents" : 3 , 
        //"indexes" : 3 ,
        //"indexSize" : 23 ,
        //"fileSize" : 16384 ,
        //"nsSizeMB" : 16 ,
        //"dataFileVersion" : { "major" : 4 , "minor" : 5} ,
        //"ok" : 1.0
    }
}
