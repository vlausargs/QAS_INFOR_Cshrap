//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_PrintBankReconciliationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_PrintBankReconciliationFactory
	{
		public ICHSRpt_PrintBankReconciliation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_PrintBankReconciliation = new Reporting.CHSRpt_PrintBankReconciliation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_PrintBankReconciliationExt = timerfactory.Create<Reporting.ICHSRpt_PrintBankReconciliation>(_CHSRpt_PrintBankReconciliation);
			
			return iCHSRpt_PrintBankReconciliationExt;
		}
	}
}
