//PROJECT NAME: CSICustomer
//CLASS NAME: EdiPostCoCustPoExistsWarningFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EdiPostCoCustPoExistsWarningFactory
	{
		public IEdiPostCoCustPoExistsWarning Create(IApplicationDB appDB)
		{
			var _EdiPostCoCustPoExistsWarning = new Logistics.Customer.EdiPostCoCustPoExistsWarning(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEdiPostCoCustPoExistsWarningExt = timerfactory.Create<Logistics.Customer.IEdiPostCoCustPoExistsWarning>(_EdiPostCoCustPoExistsWarning);
			
			return iEdiPostCoCustPoExistsWarningExt;
		}
	}
}
