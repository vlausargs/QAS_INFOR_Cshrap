//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigLoadTreeLevelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigLoadTreeLevelFactory
	{
		public ISSSFSConfigLoadTreeLevel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSConfigLoadTreeLevel = new Logistics.FieldService.SSSFSConfigLoadTreeLevel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConfigLoadTreeLevelExt = timerfactory.Create<Logistics.FieldService.ISSSFSConfigLoadTreeLevel>(_SSSFSConfigLoadTreeLevel);
			
			return iSSSFSConfigLoadTreeLevelExt;
		}
	}
}
