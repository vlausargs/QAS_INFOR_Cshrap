//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitByLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitByLoadFactory
	{
		public ISSSFSUnitByLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSUnitByLoad = new Logistics.FieldService.SSSFSUnitByLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitByLoadExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitByLoad>(_SSSFSUnitByLoad);
			
			return iSSSFSUnitByLoadExt;
		}
	}
}
