//PROJECT NAME: Finance
//CLASS NAME: VoidPRPostedPaymentDelFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class VoidPRPostedPaymentDelFactory
	{
		public IVoidPRPostedPaymentDel Create(IApplicationDB appDB)
		{
			var _VoidPRPostedPaymentDel = new Finance.VoidPRPostedPaymentDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidPRPostedPaymentDelExt = timerfactory.Create<Finance.IVoidPRPostedPaymentDel>(_VoidPRPostedPaymentDel);
			
			return iVoidPRPostedPaymentDelExt;
		}
	}
}
