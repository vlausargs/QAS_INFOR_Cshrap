//PROJECT NAME: Logistics
//CLASS NAME: PostRemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PostRemFactory
	{
		public IPostRem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostRem = new Logistics.Vendor.PostRem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostRemExt = timerfactory.Create<Logistics.Vendor.IPostRem>(_PostRem);
			
			return iPostRemExt;
		}
	}
}
