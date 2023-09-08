//PROJECT NAME: Logistics
//CLASS NAME: PostRemVerifyPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PostRemVerifyPrintFactory
	{
		public IPostRemVerifyPrint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostRemVerifyPrint = new Logistics.Vendor.PostRemVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostRemVerifyPrintExt = timerfactory.Create<Logistics.Vendor.IPostRemVerifyPrint>(_PostRemVerifyPrint);
			
			return iPostRemVerifyPrintExt;
		}
	}
}
