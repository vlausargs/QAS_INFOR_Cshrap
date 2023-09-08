//PROJECT NAME: CSICustomer
//CLASS NAME: GetCurrCodeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCurrCodeFactory
	{
		public IGetCurrCode Create(IApplicationDB appDB)
		{
			var _GetCurrCode = new Logistics.Customer.GetCurrCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCurrCodeExt = timerfactory.Create<Logistics.Customer.IGetCurrCode>(_GetCurrCode);
			
			return iGetCurrCodeExt;
		}
	}
}
