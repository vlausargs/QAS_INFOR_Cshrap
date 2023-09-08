//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyUseItFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCopyUseItFactory
	{
		public ISSSFSSroCopyUseIt Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSroCopyUseIt = new Logistics.FieldService.Requests.SSSFSSroCopyUseIt(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCopyUseItExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCopyUseIt>(_SSSFSSroCopyUseIt);
			
			return iSSSFSSroCopyUseItExt;
		}
	}
}
