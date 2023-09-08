//PROJECT NAME: Reporting
//CLASS NAME: RSQC_FamilyTestsSupplierWorksheetSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RSQC_FamilyTestsSupplierWorksheetSSRSFactory
	{
		public IRSQC_FamilyTestsSupplierWorksheetSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_FamilyTestsSupplierWorksheetSSRS = new Reporting.RSQC_FamilyTestsSupplierWorksheetSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_FamilyTestsSupplierWorksheetSSRSExt = timerfactory.Create<Reporting.IRSQC_FamilyTestsSupplierWorksheetSSRS>(_RSQC_FamilyTestsSupplierWorksheetSSRS);
			
			return iRSQC_FamilyTestsSupplierWorksheetSSRSExt;
		}
	}
}
