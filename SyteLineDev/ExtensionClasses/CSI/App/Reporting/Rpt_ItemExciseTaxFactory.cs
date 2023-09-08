//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemExciseTaxFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemExciseTaxFactory
	{
		public IRpt_ItemExciseTax Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemExciseTax = new Reporting.Rpt_ItemExciseTax(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemExciseTaxExt = timerfactory.Create<Reporting.IRpt_ItemExciseTax>(_Rpt_ItemExciseTax);
			
			return iRpt_ItemExciseTaxExt;
		}
	}
}
