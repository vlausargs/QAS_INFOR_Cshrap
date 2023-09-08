//PROJECT NAME: Logistics
//CLASS NAME: PochgP1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PochgP1Factory
	{
		public IPochgP1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PochgP1 = new Logistics.Vendor.PochgP1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPochgP1Ext = timerfactory.Create<Logistics.Vendor.IPochgP1>(_PochgP1);
			
			return iPochgP1Ext;
		}
	}
}
