//PROJECT NAME: Logistics
//CLASS NAME: GetEFTOutInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetEFTOutInfoFactory
	{
		public IGetEFTOutInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetEFTOutInfo = new Logistics.Vendor.GetEFTOutInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetEFTOutInfoExt = timerfactory.Create<Logistics.Vendor.IGetEFTOutInfo>(_GetEFTOutInfo);
			
			return iGetEFTOutInfoExt;
		}
	}
}
