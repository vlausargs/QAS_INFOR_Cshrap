//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContactLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContactLoadFactory
	{
		public ISSSFSContactLoad Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
			var _SSSFSContactLoad = new Logistics.FieldService.SSSFSContactLoad(appDB, dataTableToCollectionLoadResponse, dataTableUtil);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContactLoadExt = timerfactory.Create<Logistics.FieldService.ISSSFSContactLoad>(_SSSFSContactLoad);
			
			return iSSSFSContactLoadExt;
		}
	}
}
