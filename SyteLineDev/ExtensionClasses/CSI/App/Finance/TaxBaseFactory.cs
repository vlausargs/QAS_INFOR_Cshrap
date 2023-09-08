//PROJECT NAME: Finance
//CLASS NAME: TaxBaseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class TaxBaseFactory
	{
		public ITaxBase Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			
			var _TaxBase = new Finance.TaxBase(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxBaseExt = timerfactory.Create<Finance.ITaxBase>(_TaxBase);
			
			return iTaxBaseExt;
		}
	}
}
