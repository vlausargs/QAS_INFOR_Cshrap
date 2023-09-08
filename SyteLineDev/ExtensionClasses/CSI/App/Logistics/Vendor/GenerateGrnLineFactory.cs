//PROJECT NAME: Logistics
//CLASS NAME: GenerateGrnLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GenerateGrnLineFactory
	{
		public IGenerateGrnLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateGrnLine = new Logistics.Vendor.GenerateGrnLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateGrnLineExt = timerfactory.Create<Logistics.Vendor.IGenerateGrnLine>(_GenerateGrnLine);
			
			return iGenerateGrnLineExt;
		}
	}
}
