//PROJECT NAME: Production
//CLASS NAME: SetPrintQuoteSectionPriceFactory.cs

using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class SetPrintQuoteSectionPriceFactory
	{
		public ISetPrintQuoteSectionPrice Create(IApplicationDB appDB)
		{
			var _SetPrintQuoteSectionPrice = new Production.PrintingPackaging.SetPrintQuoteSectionPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetPrintQuoteSectionPriceExt = timerfactory.Create<Production.PrintingPackaging.ISetPrintQuoteSectionPrice>(_SetPrintQuoteSectionPrice);
			
			return iSetPrintQuoteSectionPriceExt;
		}
	}
}
