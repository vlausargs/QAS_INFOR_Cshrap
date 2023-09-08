//PROJECT NAME: Logistics
//CLASS NAME: GetEftOutfileInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetEftOutfileInfoFactory
	{
		public IGetEftOutfileInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetEftOutfileInfo = new Logistics.Vendor.GetEftOutfileInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetEftOutfileInfoExt = timerfactory.Create<Logistics.Vendor.IGetEftOutfileInfo>(_GetEftOutfileInfo);
			
			return iGetEftOutfileInfoExt;
		}
	}
}
