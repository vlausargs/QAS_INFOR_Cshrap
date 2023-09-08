//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmPostUtilFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAcmPostUtilFactory
	{
		public ISSSFSAcmPostUtil Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSAcmPostUtil = new Logistics.FieldService.SSSFSAcmPostUtil(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSAcmPostUtilExt = timerfactory.Create<Logistics.FieldService.ISSSFSAcmPostUtil>(_SSSFSAcmPostUtil);
			
			return iSSSFSAcmPostUtilExt;
		}
	}
}
