using System;
using CSI.Data.Cache;
using CSI.MG;

namespace CSI.Data.SQL
{
    public class SQLBunchedLoadCollection : IBunchedLoadCollection
    {
        IMGBunchedRequest mgBunchedRequest;
        IProcessVariableProvider processVariableProvider;
        const int defaultRecordCap = 200;

        public SQLBunchedLoadCollection(IProcessVariableProvider processVariableProvider, IMGBunchedRequest mgBunchedRequest)
        {
            this.mgBunchedRequest = mgBunchedRequest;
            this.processVariableProvider = processVariableProvider;
        }

        public void EndBunching()
        {
            mgBunchedRequest.Bookmark = processVariableProvider.GetProcessVariable("Bookmark"); //Coding standard Violation.  And, we don't need to get this here.  It's in the process variable and we're at the end so this instance is about to get garbage collected anyways
            string recordCapStr = processVariableProvider.GetProcessVariable("RecordCap");
            int recordCap;
            if (int.TryParse(recordCapStr, out recordCap) && mgBunchedRequest.RecordCap < recordCap)
            {
                mgBunchedRequest.RecordCap = recordCap; //Coding standard Violation.  And, we don't need to get this here.  It's in the process variable and we're at the end so this instance is about to get garbage collected anyways
            }
        }

        public void StartBunching()
        {
            var enableBookMark = Convert.ToString(mgBunchedRequest.EnableBookmark);
            var bookmark = mgBunchedRequest.Bookmark;
            int recordCapValue = mgBunchedRequest.RecordCap;
            if(recordCapValue == -1)
            {
                recordCapValue = defaultRecordCap;
            }
            else if(recordCapValue == 0)
            {
                recordCapValue = int.MaxValue;
            }
            
            var recordCap = Convert.ToString(recordCapValue);
            var loadType = Convert.ToString(mgBunchedRequest.LoadType);

            processVariableProvider.SetProcessVariableBatch(
                "EnableBookmark", enableBookMark,
                "Bookmark", bookmark,
                "LoadType", loadType,
                "RecordCap", recordCap);
        }

        public LoadType LoadType
        {
            get
            {
                return mgBunchedRequest.LoadType;
            }
        }

        public int RecordCap
        {
            get
            {
                return mgBunchedRequest.RecordCap;
            }
        }
    }    
}
