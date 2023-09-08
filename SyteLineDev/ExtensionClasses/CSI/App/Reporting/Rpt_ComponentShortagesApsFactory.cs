//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ComponentShortagesApsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ComponentShortagesApsFactory
	{
		public IRpt_ComponentShortagesAps Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ComponentShortagesAps = new Reporting.Rpt_ComponentShortagesAps(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ComponentShortagesApsExt = timerfactory.Create<Reporting.IRpt_ComponentShortagesAps>(_Rpt_ComponentShortagesAps);
			
			return iRpt_ComponentShortagesApsExt;
		}
	}
}
