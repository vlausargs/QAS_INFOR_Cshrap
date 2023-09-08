//PROJECT NAME: Reporting
//CLASS NAME: SSSCCIRpt_ShippingAuthFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSCCIRpt_ShippingAuthFactory
	{
		public ISSSCCIRpt_ShippingAuth Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSCCIRpt_ShippingAuth = new Reporting.SSSCCIRpt_ShippingAuth(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIRpt_ShippingAuthExt = timerfactory.Create<Reporting.ISSSCCIRpt_ShippingAuth>(_SSSCCIRpt_ShippingAuth);
			
			return iSSSCCIRpt_ShippingAuthExt;
		}
	}
}
