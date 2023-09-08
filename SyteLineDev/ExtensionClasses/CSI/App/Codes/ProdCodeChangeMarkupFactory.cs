//PROJECT NAME: Codes
//CLASS NAME: ProdCodeChangeMarkupFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class ProdCodeChangeMarkupFactory
	{
		public IProdCodeChangeMarkup Create(IApplicationDB appDB)
		{
			var _ProdCodeChangeMarkup = new Codes.ProdCodeChangeMarkup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProdCodeChangeMarkupExt = timerfactory.Create<Codes.IProdCodeChangeMarkup>(_ProdCodeChangeMarkup);
			
			return iProdCodeChangeMarkupExt;
		}
	}
}
