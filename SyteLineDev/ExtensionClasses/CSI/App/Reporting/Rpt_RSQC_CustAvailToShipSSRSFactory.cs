//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CustAvailToShipSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CustAvailToShipSSRSFactory
	{
		public IRpt_RSQC_CustAvailToShipSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CustAvailToShipSSRS = new Reporting.Rpt_RSQC_CustAvailToShipSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CustAvailToShipSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CustAvailToShipSSRS>(_Rpt_RSQC_CustAvailToShipSSRS);
			
			return iRpt_RSQC_CustAvailToShipSSRSExt;
		}
	}
}
