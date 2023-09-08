//PROJECT NAME: Production
//CLASS NAME: PmfPnLoadJobsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
    public class PmfPnLoadJobsFactory
    {
        public IPmfPnLoadJobs Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _PmfPnLoadJobs = new Production.PmfPnLoadJobs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPmfPnLoadJobsExt = timerfactory.Create<Production.IPmfPnLoadJobs>(_PmfPnLoadJobs);

            return iPmfPnLoadJobsExt;
        }
    }
}
