//PROJECT NAME: CSICustomer
//CLASS NAME: GetCommBaseFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCommBaseFactory
	{
		public IGetCommBase Create(IApplicationDB appDB)
		{
			var _GetCommBase = new Logistics.Customer.GetCommBase(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCommBaseExt = timerfactory.Create<Logistics.Customer.IGetCommBase>(_GetCommBase);
			
			return iGetCommBaseExt;
		}
	}
}
