//PROJECT NAME: Logistics
//CLASS NAME: GetApparmsEFTInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetApparmsEFTInfoFactory
	{
		public IGetApparmsEFTInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetApparmsEFTInfo = new Logistics.Vendor.GetApparmsEFTInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetApparmsEFTInfoExt = timerfactory.Create<Logistics.Vendor.IGetApparmsEFTInfo>(_GetApparmsEFTInfo);
			
			return iGetApparmsEFTInfoExt;
		}
	}
}
