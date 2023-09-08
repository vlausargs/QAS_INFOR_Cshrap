//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProfileConInvoicingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSProfileConInvoicingFactory
	{
		public ISSSFSProfileConInvoicing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSProfileConInvoicing = new Logistics.FieldService.SSSFSProfileConInvoicing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSProfileConInvoicingExt = timerfactory.Create<Logistics.FieldService.ISSSFSProfileConInvoicing>(_SSSFSProfileConInvoicing);
			
			return iSSSFSProfileConInvoicingExt;
		}
	}
}
