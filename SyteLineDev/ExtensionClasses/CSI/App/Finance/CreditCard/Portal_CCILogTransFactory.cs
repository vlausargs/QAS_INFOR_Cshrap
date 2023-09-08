//PROJECT NAME: Finance
//CLASS NAME: Portal_CCILogTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCILogTransFactory
	{
		public IPortal_CCILogTrans Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Portal_CCILogTrans = new Finance.CreditCard.Portal_CCILogTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_CCILogTransExt = timerfactory.Create<Finance.CreditCard.IPortal_CCILogTrans>(_Portal_CCILogTrans);
			
			return iPortal_CCILogTransExt;
		}
	}
}
