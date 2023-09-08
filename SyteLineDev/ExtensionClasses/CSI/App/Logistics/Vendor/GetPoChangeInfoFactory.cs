//PROJECT NAME: Logistics
//CLASS NAME: GetPoChangeInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetPoChangeInfoFactory
	{
		public IGetPoChangeInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetPoChangeInfo = new Logistics.Vendor.GetPoChangeInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPoChangeInfoExt = timerfactory.Create<Logistics.Vendor.IGetPoChangeInfo>(_GetPoChangeInfo);
			
			return iGetPoChangeInfoExt;
		}
	}
}
