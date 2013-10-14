namespace MongoLabSurveyor.Model
{
    public class DbStatsResponse
    {
        public string ServerUsed { get; set; }

        public int Collections { get; set; }

        public int Objects { get; set; }

        public float AvgObjSize { get; set; }

        public float DataSize { get; set; }

        public float StorageSize { get; set; }

        public int NumExtents { get; set; }

        public int Indexes { get; set; }

        public float IndexSize { get; set; }

        public float FileSize { get; set; }

        public float NsSizeMB { get; set; }
    }
}
