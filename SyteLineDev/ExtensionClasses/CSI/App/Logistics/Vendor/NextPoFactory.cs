//PROJECT NAME: Logistics
//CLASS NAME: NextPoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class NextPoFactory
	{
		public INextPo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _NextPo = new Logistics.Vendor.NextPo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextPoExt = timerfactory.Create<Logistics.Vendor.INextPo>(_NextPo);
			
			return iNextPoExt;
		}
	}
}
