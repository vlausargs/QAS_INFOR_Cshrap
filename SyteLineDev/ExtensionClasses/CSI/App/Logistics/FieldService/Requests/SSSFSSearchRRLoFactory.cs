//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSearchRRLoFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSearchRRLoFactory
    {
        public ISSSFSSearchRRLo Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _SSSFSSearchRRLo = new Logistics.FieldService.Requests.SSSFSSearchRRLo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSearchRRLoExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSearchRRLo>(_SSSFSSearchRRLo);

            return iSSSFSSearchRRLoExt;
        }
    }
}
