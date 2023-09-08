//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipHdr_LoadFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROPackSlipHdr_LoadFactory
	{
		public ISSSFSSROPackSlipHdr_Load Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSROPackSlipHdr_Load = new Logistics.FieldService.Requests.SSSFSSROPackSlipHdr_Load(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROPackSlipHdr_LoadExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROPackSlipHdr_Load>(_SSSFSSROPackSlipHdr_Load);
			
			return iSSSFSSROPackSlipHdr_LoadExt;
		}
	}
}
