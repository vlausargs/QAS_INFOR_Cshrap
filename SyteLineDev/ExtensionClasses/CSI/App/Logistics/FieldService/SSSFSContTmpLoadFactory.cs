//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContTmpLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContTmpLoadFactory
	{
		public ISSSFSContTmpLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSContTmpLoad = new Logistics.FieldService.SSSFSContTmpLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContTmpLoadExt = timerfactory.Create<Logistics.FieldService.ISSSFSContTmpLoad>(_SSSFSContTmpLoad);
			
			return iSSSFSContTmpLoadExt;
		}
	}
}
