//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_VRMAPackSlipSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_VRMAPackSlipSSRSFactory
	{
		public IRpt_RSQC_VRMAPackSlipSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_VRMAPackSlipSSRS = new Reporting.Rpt_RSQC_VRMAPackSlipSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_VRMAPackSlipSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_VRMAPackSlipSSRS>(_Rpt_RSQC_VRMAPackSlipSSRS);
			
			return iRpt_RSQC_VRMAPackSlipSSRSExt;
		}
	}
}
