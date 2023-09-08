//PROJECT NAME: Logistics
//CLASS NAME: MaterialDistributionCustUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class MaterialDistributionCustUpdFactory
	{
		public IMaterialDistributionCustUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MaterialDistributionCustUpd = new Logistics.Vendor.MaterialDistributionCustUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMaterialDistributionCustUpdExt = timerfactory.Create<Logistics.Vendor.IMaterialDistributionCustUpd>(_MaterialDistributionCustUpd);
			
			return iMaterialDistributionCustUpdExt;
		}
	}
}
