using CSI.Data.Cache;
using CSI.MG;

namespace CSI.Data.SQL
{
    public class SQLBunchedRequest : IMGBunchedRequest
    {
        readonly ISQLBunchingContext mgBunchingContext;
        public SQLBunchedRequest(ISQLBunchingContext mgBunchingContext)
        {
            this.mgBunchingContext = mgBunchingContext;
        }

        public bool EnableBookmark
        {
            get { return mgBunchingContext.EnableBookmark; }
            set { mgBunchingContext.EnableBookmark = value;}

        }
        public string Bookmark
        {
            get { return mgBunchingContext.Bookmark; }
            set { mgBunchingContext.Bookmark = value; }
        }
        public int RecordCap
        {
            get { return mgBunchingContext.RecordCap; }
            set { mgBunchingContext.RecordCap = value; }
        }
        public LoadType LoadType => mgBunchingContext.LoadType;
    }
}