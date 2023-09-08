//PROJECT NAME: Reporting
//CLASS NAME: Rpt_UmCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_UmCheckFactory
	{
		public IRpt_UmCheck Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_UmCheck = new Reporting.Rpt_UmCheck(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_UmCheckExt = timerfactory.Create<Reporting.IRpt_UmCheck>(_Rpt_UmCheck);
			
			return iRpt_UmCheckExt;
		}
	}
}
