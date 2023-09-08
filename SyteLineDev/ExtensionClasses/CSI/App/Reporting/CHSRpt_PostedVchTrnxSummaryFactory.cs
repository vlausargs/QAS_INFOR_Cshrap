//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_PostedVchTrnxSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_PostedVchTrnxSummaryFactory
	{
		public ICHSRpt_PostedVchTrnxSummary Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_PostedVchTrnxSummary = new Reporting.CHSRpt_PostedVchTrnxSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_PostedVchTrnxSummaryExt = timerfactory.Create<Reporting.ICHSRpt_PostedVchTrnxSummary>(_CHSRpt_PostedVchTrnxSummary);
			
			return iCHSRpt_PostedVchTrnxSummaryExt;
		}
	}
}
