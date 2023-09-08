//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_PostedVchTrnxByAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_PostedVchTrnxByAcctFactory
	{
		public ICHSRpt_PostedVchTrnxByAcct Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_PostedVchTrnxByAcct = new Reporting.CHSRpt_PostedVchTrnxByAcct(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_PostedVchTrnxByAcctExt = timerfactory.Create<Reporting.ICHSRpt_PostedVchTrnxByAcct>(_CHSRpt_PostedVchTrnxByAcct);
			
			return iCHSRpt_PostedVchTrnxByAcctExt;
		}
	}
}
