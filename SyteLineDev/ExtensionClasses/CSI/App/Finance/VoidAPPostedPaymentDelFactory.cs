//PROJECT NAME: Finance
//CLASS NAME: VoidAPPostedPaymentDelFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class VoidAPPostedPaymentDelFactory
	{
		public IVoidAPPostedPaymentDel Create(IApplicationDB appDB)
		{
			var _VoidAPPostedPaymentDel = new Finance.VoidAPPostedPaymentDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidAPPostedPaymentDelExt = timerfactory.Create<Finance.IVoidAPPostedPaymentDel>(_VoidAPPostedPaymentDel);
			
			return iVoidAPPostedPaymentDelExt;
		}
	}
}
