//PROJECT NAME: Logistics
//CLASS NAME: PoapGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoapGenFactory
	{
		public IPoapGen Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoapGen = new Logistics.Vendor.PoapGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoapGenExt = timerfactory.Create<Logistics.Vendor.IPoapGen>(_PoapGen);
			
			return iPoapGenExt;
		}
	}
}
