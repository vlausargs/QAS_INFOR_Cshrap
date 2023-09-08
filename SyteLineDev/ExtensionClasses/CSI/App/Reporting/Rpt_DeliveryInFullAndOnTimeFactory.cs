//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DeliveryInFullAndOnTimeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DeliveryInFullAndOnTimeFactory
	{
		public IRpt_DeliveryInFullAndOnTime Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DeliveryInFullAndOnTime = new Reporting.Rpt_DeliveryInFullAndOnTime(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DeliveryInFullAndOnTimeExt = timerfactory.Create<Reporting.IRpt_DeliveryInFullAndOnTime>(_Rpt_DeliveryInFullAndOnTime);
			
			return iRpt_DeliveryInFullAndOnTimeExt;
		}
	}
}
