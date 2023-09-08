//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjRetTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjRetTransFactory
	{
		public IRpt_ProjRetTrans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjRetTrans = new Reporting.Rpt_ProjRetTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjRetTransExt = timerfactory.Create<Reporting.IRpt_ProjRetTrans>(_Rpt_ProjRetTrans);
			
			return iRpt_ProjRetTransExt;
		}
	}
}
