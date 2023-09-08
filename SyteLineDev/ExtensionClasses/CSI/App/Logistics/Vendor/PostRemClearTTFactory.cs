//PROJECT NAME: Logistics
//CLASS NAME: PostRemClearTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PostRemClearTTFactory
	{
		public IPostRemClearTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostRemClearTT = new Logistics.Vendor.PostRemClearTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostRemClearTTExt = timerfactory.Create<Logistics.Vendor.IPostRemClearTT>(_PostRemClearTT);
			
			return iPostRemClearTTExt;
		}
	}
}
