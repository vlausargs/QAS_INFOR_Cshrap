//PROJECT NAME: Logistics
//CLASS NAME: ValidateSalesPersonNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateSalesPersonNumFactory
	{
		public IValidateSalesPersonNum Create(IApplicationDB appDB)
		{
			var _ValidateSalesPersonNum = new Logistics.Customer.ValidateSalesPersonNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateSalesPersonNumExt = timerfactory.Create<Logistics.Customer.IValidateSalesPersonNum>(_ValidateSalesPersonNum);
			
			return iValidateSalesPersonNumExt;
		}
	}
}
