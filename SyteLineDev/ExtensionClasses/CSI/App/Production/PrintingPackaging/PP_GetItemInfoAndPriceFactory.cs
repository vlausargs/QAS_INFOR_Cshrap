//PROJECT NAME: Production
//CLASS NAME: PP_GetItemInfoAndPriceFactory.cs

using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_GetItemInfoAndPriceFactory
	{
		public IPP_GetItemInfoAndPrice Create(IApplicationDB appDB)
		{
			var _PP_GetItemInfoAndPrice = new Production.PrintingPackaging.PP_GetItemInfoAndPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_GetItemInfoAndPriceExt = timerfactory.Create<Production.PrintingPackaging.IPP_GetItemInfoAndPrice>(_PP_GetItemInfoAndPrice);
			
			return iPP_GetItemInfoAndPriceExt;
		}
	}
}
