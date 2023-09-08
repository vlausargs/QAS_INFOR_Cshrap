//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_OutputLedgerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_OutputLedgerFactory
	{
		public ICHSRpt_OutputLedger Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_OutputLedger = new Reporting.CHSRpt_OutputLedger(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_OutputLedgerExt = timerfactory.Create<Reporting.ICHSRpt_OutputLedger>(_CHSRpt_OutputLedger);
			
			return iCHSRpt_OutputLedgerExt;
		}
	}
}
