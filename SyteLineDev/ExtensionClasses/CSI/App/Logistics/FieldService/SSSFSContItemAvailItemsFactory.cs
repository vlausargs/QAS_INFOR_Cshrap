//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContItemAvailItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContItemAvailItemsFactory
	{
		public ISSSFSContItemAvailItems Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSContItemAvailItems = new Logistics.FieldService.SSSFSContItemAvailItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContItemAvailItemsExt = timerfactory.Create<Logistics.FieldService.ISSSFSContItemAvailItems>(_SSSFSContItemAvailItems);
			
			return iSSSFSContItemAvailItemsExt;
		}
	}
}
