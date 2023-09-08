//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProfileSROPackSlipFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSProfileSROPackSlipFactory
	{
		public ISSSFSProfileSROPackSlip Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSProfileSROPackSlip = new Logistics.FieldService.Requests.SSSFSProfileSROPackSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSProfileSROPackSlipExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSProfileSROPackSlip>(_SSSFSProfileSROPackSlip);
			
			return iSSSFSProfileSROPackSlipExt;
		}
	}
}
