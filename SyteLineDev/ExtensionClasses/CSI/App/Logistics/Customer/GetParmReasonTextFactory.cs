//PROJECT NAME: CSICustomer
//CLASS NAME: GetParmReasonTextFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetParmReasonTextFactory
	{
		public IGetParmReasonText Create(IApplicationDB appDB)
		{
			var _GetParmReasonText = new Logistics.Customer.GetParmReasonText(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetParmReasonTextExt = timerfactory.Create<Logistics.Customer.IGetParmReasonText>(_GetParmReasonText);
			
			return iGetParmReasonTextExt;
		}
	}
}
