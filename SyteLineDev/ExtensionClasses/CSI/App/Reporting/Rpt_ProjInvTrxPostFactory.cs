//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjInvTrxPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjInvTrxPostFactory
	{
		public IRpt_ProjInvTrxPost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjInvTrxPost = new Reporting.Rpt_ProjInvTrxPost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjInvTrxPostExt = timerfactory.Create<Reporting.IRpt_ProjInvTrxPost>(_Rpt_ProjInvTrxPost);
			
			return iRpt_ProjInvTrxPostExt;
		}
	}
}
