//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_DetailLeftOverFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_DetailLeftOverFactory
	{
		public ICHSRpt_DetailLeftOver Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_DetailLeftOver = new Reporting.CHSRpt_DetailLeftOver(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_DetailLeftOverExt = timerfactory.Create<Reporting.ICHSRpt_DetailLeftOver>(_CHSRpt_DetailLeftOver);
			
			return iCHSRpt_DetailLeftOverExt;
		}
	}
}
