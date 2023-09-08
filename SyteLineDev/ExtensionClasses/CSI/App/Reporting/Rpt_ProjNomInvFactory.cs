//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjNomInvFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjNomInvFactory
	{
		public IRpt_ProjNomInv Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjNomInv = new Reporting.Rpt_ProjNomInv(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjNomInvExt = timerfactory.Create<Reporting.IRpt_ProjNomInv>(_Rpt_ProjNomInv);
			
			return iRpt_ProjNomInvExt;
		}
	}
}
