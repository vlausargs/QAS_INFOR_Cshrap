//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CfgAttrFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CfgAttrFactory
	{
		public IRpt_CfgAttr Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CfgAttr = new Reporting.Rpt_CfgAttr(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CfgAttrExt = timerfactory.Create<Reporting.IRpt_CfgAttr>(_Rpt_CfgAttr);
			
			return iRpt_CfgAttrExt;
		}
	}
}
