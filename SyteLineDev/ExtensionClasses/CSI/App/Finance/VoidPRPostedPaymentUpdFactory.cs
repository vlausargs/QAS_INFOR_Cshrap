//PROJECT NAME: Finance
//CLASS NAME: VoidPRPostedPaymentUpdFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class VoidPRPostedPaymentUpdFactory
	{
		public IVoidPRPostedPaymentUpd Create(IApplicationDB appDB)
		{
			var _VoidPRPostedPaymentUpd = new Finance.VoidPRPostedPaymentUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidPRPostedPaymentUpdExt = timerfactory.Create<Finance.IVoidPRPostedPaymentUpd>(_VoidPRPostedPaymentUpd);
			
			return iVoidPRPostedPaymentUpdExt;
		}
	}
}
