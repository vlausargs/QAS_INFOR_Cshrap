//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetARAgingInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_GetARAgingInfoFactory
	{
		public ICLM_GetARAgingInfo Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_GetARAgingInfo = new Logistics.Customer.CLM_GetARAgingInfo(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetARAgingInfoExt = timerfactory.Create<Logistics.Customer.ICLM_GetARAgingInfo>(_CLM_GetARAgingInfo);
			
			return iCLM_GetARAgingInfoExt;
		}
	}
}
