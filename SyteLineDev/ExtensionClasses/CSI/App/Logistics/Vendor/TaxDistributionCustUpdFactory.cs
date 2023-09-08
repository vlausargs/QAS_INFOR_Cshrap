//PROJECT NAME: Logistics
//CLASS NAME: TaxDistributionCustUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class TaxDistributionCustUpdFactory
	{
		public ITaxDistributionCustUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TaxDistributionCustUpd = new Logistics.Vendor.TaxDistributionCustUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxDistributionCustUpdExt = timerfactory.Create<Logistics.Vendor.ITaxDistributionCustUpd>(_TaxDistributionCustUpd);
			
			return iTaxDistributionCustUpdExt;
		}
	}
}
