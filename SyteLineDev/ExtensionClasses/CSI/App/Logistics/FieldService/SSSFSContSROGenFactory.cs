//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContSROGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContSROGenFactory
	{
		public ISSSFSContSROGen Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSContSROGen = new Logistics.FieldService.SSSFSContSROGen(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContSROGenExt = timerfactory.Create<Logistics.FieldService.ISSSFSContSROGen>(_SSSFSContSROGen);
			
			return iSSSFSContSROGenExt;
		}
	}
}
