//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AP01RIPrelimRegFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_AP01RIPrelimRegFactory
	{
		public IRpt_AP01RIPrelimReg Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_AP01RIPrelimReg = new Reporting.Rpt_AP01RIPrelimReg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_AP01RIPrelimRegExt = timerfactory.Create<Reporting.IRpt_AP01RIPrelimReg>(_Rpt_AP01RIPrelimReg);
			
			return iRpt_AP01RIPrelimRegExt;
		}
	}
}
