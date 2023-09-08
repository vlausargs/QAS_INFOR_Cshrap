//PROJECT NAME: Reporting
//CLASS NAME: RSQC_FamilyTestsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_FamilyTestsSSRSFactory
	{
		public IRSQC_FamilyTestsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_FamilyTestsSSRS = new Reporting.RSQC_FamilyTestsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_FamilyTestsSSRSExt = timerfactory.Create<Reporting.IRSQC_FamilyTestsSSRS>(_RSQC_FamilyTestsSSRS);
			
			return iRSQC_FamilyTestsSSRSExt;
		}
	}
}
