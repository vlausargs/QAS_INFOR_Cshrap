//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipLine_LoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROPackSlipLine_LoadFactory
	{
		public ISSSFSSROPackSlipLine_Load Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSROPackSlipLine_Load = new Logistics.FieldService.Requests.SSSFSSROPackSlipLine_Load(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROPackSlipLine_LoadExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROPackSlipLine_Load>(_SSSFSSROPackSlipLine_Load);
			
			return iSSSFSSROPackSlipLine_LoadExt;
		}
	}
}
