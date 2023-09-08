//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerOrderKitPickListFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CustomerOrderKitPickListFactory
	{
		public IRpt_CustomerOrderKitPickList Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerOrderKitPickList = new Reporting.Rpt_CustomerOrderKitPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerOrderKitPickListExt = timerfactory.Create<Reporting.IRpt_CustomerOrderKitPickList>(_Rpt_CustomerOrderKitPickList);
			
			return iRpt_CustomerOrderKitPickListExt;
		}
	}
}
