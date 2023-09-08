//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MaterialUseUpFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MaterialUseUpFactory
	{
		public IRpt_MaterialUseUp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MaterialUseUp = new Reporting.Rpt_MaterialUseUp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MaterialUseUpExt = timerfactory.Create<Reporting.IRpt_MaterialUseUp>(_Rpt_MaterialUseUp);
			
			return iRpt_MaterialUseUpExt;
		}
	}
}
