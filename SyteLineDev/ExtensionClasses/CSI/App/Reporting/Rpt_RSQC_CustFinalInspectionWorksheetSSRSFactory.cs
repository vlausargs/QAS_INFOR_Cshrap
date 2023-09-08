//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CustFinalInspectionWorksheetSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CustFinalInspectionWorksheetSSRSFactory
	{
		public IRpt_RSQC_CustFinalInspectionWorksheetSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CustFinalInspectionWorksheetSSRS = new Reporting.Rpt_RSQC_CustFinalInspectionWorksheetSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CustFinalInspectionWorksheetSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CustFinalInspectionWorksheetSSRS>(_Rpt_RSQC_CustFinalInspectionWorksheetSSRS);
			
			return iRpt_RSQC_CustFinalInspectionWorksheetSSRSExt;
		}
	}
}
