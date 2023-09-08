//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQLoadHdrVendorsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.RFQ
{
	public class SSSRFQLoadHdrVendorsFactory
	{
		public ISSSRFQLoadHdrVendors Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRFQLoadHdrVendors = new RFQ.SSSRFQLoadHdrVendors(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQLoadHdrVendorsExt = timerfactory.Create<RFQ.ISSSRFQLoadHdrVendors>(_SSSRFQLoadHdrVendors);
			
			return iSSSRFQLoadHdrVendorsExt;
		}
	}
}
