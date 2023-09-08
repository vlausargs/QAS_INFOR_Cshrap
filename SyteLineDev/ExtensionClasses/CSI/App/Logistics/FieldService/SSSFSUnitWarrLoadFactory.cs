//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitWarrLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitWarrLoadFactory
	{
		public ISSSFSUnitWarrLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSUnitWarrLoad = new Logistics.FieldService.SSSFSUnitWarrLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitWarrLoadExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitWarrLoad>(_SSSFSUnitWarrLoad);
			
			return iSSSFSUnitWarrLoadExt;
		}
	}
}
