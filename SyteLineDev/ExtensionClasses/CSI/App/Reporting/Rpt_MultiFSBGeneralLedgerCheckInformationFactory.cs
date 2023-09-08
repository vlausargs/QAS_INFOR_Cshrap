//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerCheckInformationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerCheckInformationFactory
	{
		public IRpt_MultiFSBGeneralLedgerCheckInformation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBGeneralLedgerCheckInformation = new Reporting.Rpt_MultiFSBGeneralLedgerCheckInformation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBGeneralLedgerCheckInformationExt = timerfactory.Create<Reporting.IRpt_MultiFSBGeneralLedgerCheckInformation>(_Rpt_MultiFSBGeneralLedgerCheckInformation);
			
			return iRpt_MultiFSBGeneralLedgerCheckInformationExt;
		}
	}
}
