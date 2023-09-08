//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAutoSROGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAutoSROGenFactory
	{
		public ISSSFSAutoSROGen Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSAutoSROGen = new Logistics.FieldService.SSSFSAutoSROGen(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSAutoSROGenExt = timerfactory.Create<Logistics.FieldService.ISSSFSAutoSROGen>(_SSSFSAutoSROGen);
			
			return iSSSFSAutoSROGenExt;
		}
	}
}
