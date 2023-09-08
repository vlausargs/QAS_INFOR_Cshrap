//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BarcodedEmployeeBadgesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_BarcodedEmployeeBadgesFactory
	{
		public IRpt_BarcodedEmployeeBadges Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_BarcodedEmployeeBadges = new Reporting.Rpt_BarcodedEmployeeBadges(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_BarcodedEmployeeBadgesExt = timerfactory.Create<Reporting.IRpt_BarcodedEmployeeBadges>(_Rpt_BarcodedEmployeeBadges);
			
			return iRpt_BarcodedEmployeeBadgesExt;
		}
	}
}
