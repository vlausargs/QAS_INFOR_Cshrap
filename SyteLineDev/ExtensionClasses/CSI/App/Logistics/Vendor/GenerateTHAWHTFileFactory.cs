//PROJECT NAME: Logistics
//CLASS NAME: GenerateTHAWHTFileFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GenerateTHAWHTFileFactory
	{
		public IGenerateTHAWHTFile Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateTHAWHTFile = new Logistics.Vendor.GenerateTHAWHTFile(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateTHAWHTFileExt = timerfactory.Create<Logistics.Vendor.IGenerateTHAWHTFile>(_GenerateTHAWHTFile);
			
			return iGenerateTHAWHTFileExt;
		}
	}
}
