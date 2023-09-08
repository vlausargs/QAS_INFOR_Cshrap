//PROJECT NAME: Logistics
//CLASS NAME: NextPreqFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class NextPreqFactory
	{
		public INextPreq Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _NextPreq = new Logistics.Vendor.NextPreq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextPreqExt = timerfactory.Create<Logistics.Vendor.INextPreq>(_NextPreq);
			
			return iNextPreqExt;
		}
	}
}
