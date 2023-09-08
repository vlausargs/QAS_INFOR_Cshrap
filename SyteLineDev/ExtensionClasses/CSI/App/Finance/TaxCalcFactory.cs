//PROJECT NAME: Finance
//CLASS NAME: TaxCalcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class TaxCalcFactory
	{
		public ITaxCalc Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			
			var _TaxCalc = new Finance.TaxCalc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxCalcExt = timerfactory.Create<Finance.ITaxCalc>(_TaxCalc);
			
			return iTaxCalcExt;
		}
	}
}
