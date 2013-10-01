namespace MongoLabSurveyor.Model
{
    public class DbStatsResponse
    using ViewModel;

    public class DbStatsResponse : ViewModelBase
    {
        public string serverUsed { get; set; }

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
    }
}
