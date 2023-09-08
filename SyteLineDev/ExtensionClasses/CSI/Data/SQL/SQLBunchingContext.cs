using CSI.Data.Cache;

namespace CSI.Data.SQL
{
    public class SQLBunchingContext : ISQLBunchingContext
    {
        public SQLBunchingContext(bool enableBookmark, string bookmark, int recordCap, LoadType loadType)
        {
            this.EnableBookmark = enableBookmark;
            this.Bookmark = bookmark;
            this.RecordCap = recordCap;
            this.LoadType = loadType;
        }
        public bool EnableBookmark { get; set; }
        public string Bookmark { get; set; }
        public int RecordCap { get; set; }
        public LoadType LoadType { get; }
    }
}