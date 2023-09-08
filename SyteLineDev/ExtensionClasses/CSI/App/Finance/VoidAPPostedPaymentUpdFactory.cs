//PROJECT NAME: Finance
//CLASS NAME: VoidAPPostedPaymentUpdFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class VoidAPPostedPaymentUpdFactory
	{
		public IVoidAPPostedPaymentUpd Create(IApplicationDB appDB)
		{
			var _VoidAPPostedPaymentUpd = new Finance.VoidAPPostedPaymentUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidAPPostedPaymentUpdExt = timerfactory.Create<Finance.IVoidAPPostedPaymentUpd>(_VoidAPPostedPaymentUpd);
			
			return iVoidAPPostedPaymentUpdExt;
		}
	}
}
