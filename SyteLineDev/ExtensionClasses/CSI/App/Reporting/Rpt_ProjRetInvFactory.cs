//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjRetInvFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjRetInvFactory
	{
		public IRpt_ProjRetInv Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjRetInv = new Reporting.Rpt_ProjRetInv(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjRetInvExt = timerfactory.Create<Reporting.IRpt_ProjRetInv>(_Rpt_ProjRetInv);
			
			return iRpt_ProjRetInvExt;
		}
	}
}
