//PROJECT NAME: Logistics
//CLASS NAME: CreateFixedAssetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CreateFixedAssetFactory
	{
		public ICreateFixedAsset Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateFixedAsset = new Logistics.Vendor.CreateFixedAsset(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateFixedAssetExt = timerfactory.Create<Logistics.Vendor.ICreateFixedAsset>(_CreateFixedAsset);
			
			return iCreateFixedAssetExt;
		}
	}
}
