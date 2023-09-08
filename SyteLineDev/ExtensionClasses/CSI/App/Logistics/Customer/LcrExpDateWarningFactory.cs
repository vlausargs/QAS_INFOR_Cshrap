//PROJECT NAME: CSICustomer
//CLASS NAME: LcrExpDateWarningFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class LcrExpDateWarningFactory
	{
		public ILcrExpDateWarning Create(IApplicationDB appDB)
		{
			var _LcrExpDateWarning = new Logistics.Customer.LcrExpDateWarning(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLcrExpDateWarningExt = timerfactory.Create<Logistics.Customer.ILcrExpDateWarning>(_LcrExpDateWarning);
			
			return iLcrExpDateWarningExt;
		}
	}
}
