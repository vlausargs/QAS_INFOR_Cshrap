//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigWarrLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigWarrLoadFactory
	{
		public ISSSFSUnitConfigWarrLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSUnitConfigWarrLoad = new Logistics.FieldService.SSSFSUnitConfigWarrLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitConfigWarrLoadExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitConfigWarrLoad>(_SSSFSUnitConfigWarrLoad);
			
			return iSSSFSUnitConfigWarrLoadExt;
		}
	}
}
