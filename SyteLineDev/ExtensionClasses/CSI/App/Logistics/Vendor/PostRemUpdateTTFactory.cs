//PROJECT NAME: Logistics
//CLASS NAME: PostRemUpdateTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PostRemUpdateTTFactory
	{
		public IPostRemUpdateTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostRemUpdateTT = new Logistics.Vendor.PostRemUpdateTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostRemUpdateTTExt = timerfactory.Create<Logistics.Vendor.IPostRemUpdateTT>(_PostRemUpdateTT);
			
			return iPostRemUpdateTTExt;
		}
	}
}
