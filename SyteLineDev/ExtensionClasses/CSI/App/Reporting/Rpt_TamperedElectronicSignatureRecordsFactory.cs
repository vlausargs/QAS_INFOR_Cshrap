//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TamperedElectronicSignatureRecordsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TamperedElectronicSignatureRecordsFactory
	{
		public IRpt_TamperedElectronicSignatureRecords Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TamperedElectronicSignatureRecords = new Reporting.Rpt_TamperedElectronicSignatureRecords(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TamperedElectronicSignatureRecordsExt = timerfactory.Create<Reporting.IRpt_TamperedElectronicSignatureRecords>(_Rpt_TamperedElectronicSignatureRecords);
			
			return iRpt_TamperedElectronicSignatureRecordsExt;
		}
	}
}
