//PROJECT NAME: Reporting
//CLASS NAME: RSQC_FamilyTestsIPWorksheetSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_FamilyTestsIPWorksheetSSRSFactory
	{
		public IRSQC_FamilyTestsIPWorksheetSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_FamilyTestsIPWorksheetSSRS = new Reporting.RSQC_FamilyTestsIPWorksheetSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_FamilyTestsIPWorksheetSSRSExt = timerfactory.Create<Reporting.IRSQC_FamilyTestsIPWorksheetSSRS>(_RSQC_FamilyTestsIPWorksheetSSRS);
			
			return iRSQC_FamilyTestsIPWorksheetSSRSExt;
		}
	}
}
