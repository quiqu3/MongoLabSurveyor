namespace MongoLabSurveyor.Model
{
    public class DbStatsResponse
    {
        public string ServerUsed { get; set; }

        public int Collections { get; set; }

        public int Objects { get; set; }

        public float AvgObjSize { get; set; }

        public int DataSize { get; set; }

        public int StorageSize { get; set; }

        public int NumExtents { get; set; }

        public int Indexes { get; set; }

        public int IndexSize { get; set; }

        public int FileSize { get; set; }

        public int NsSizeMB { get; set; }
    }
}
