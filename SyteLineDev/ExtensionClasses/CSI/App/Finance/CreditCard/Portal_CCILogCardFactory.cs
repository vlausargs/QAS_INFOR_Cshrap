//PROJECT NAME: Finance
//CLASS NAME: Portal_CCILogCardFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCILogCardFactory
	{
		public IPortal_CCILogCard Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Portal_CCILogCard = new Finance.CreditCard.Portal_CCILogCard(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_CCILogCardExt = timerfactory.Create<Finance.CreditCard.IPortal_CCILogCard>(_Portal_CCILogCard);
			
			return iPortal_CCILogCardExt;
		}
	}
}
