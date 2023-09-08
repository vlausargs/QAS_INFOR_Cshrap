//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ElectronicSignatureRecordsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ElectronicSignatureRecordsFactory
	{
		public IRpt_ElectronicSignatureRecords Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ElectronicSignatureRecords = new Reporting.Rpt_ElectronicSignatureRecords(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ElectronicSignatureRecordsExt = timerfactory.Create<Reporting.IRpt_ElectronicSignatureRecords>(_Rpt_ElectronicSignatureRecords);
			
			return iRpt_ElectronicSignatureRecordsExt;
		}
	}
}
