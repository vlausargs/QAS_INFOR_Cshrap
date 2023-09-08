//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCloseLoFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCloseLoFactory
	{
		public ISSSFSSroCloseLo Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSroCloseLo = new Logistics.FieldService.Requests.SSSFSSroCloseLo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCloseLoExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCloseLo>(_SSSFSSroCloseLo);
			
			return iSSSFSSroCloseLoExt;
		}
	}
}
