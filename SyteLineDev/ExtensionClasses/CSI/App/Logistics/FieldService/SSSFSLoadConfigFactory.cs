//PROJECT NAME: Logistics
//CLASS NAME: SSSFSLoadConfigFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSLoadConfigFactory
	{
		public ISSSFSLoadConfig Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSLoadConfig = new Logistics.FieldService.SSSFSLoadConfig(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSLoadConfigExt = timerfactory.Create<Logistics.FieldService.ISSSFSLoadConfig>(_SSSFSLoadConfig);
			
			return iSSSFSLoadConfigExt;
		}
	}
}
