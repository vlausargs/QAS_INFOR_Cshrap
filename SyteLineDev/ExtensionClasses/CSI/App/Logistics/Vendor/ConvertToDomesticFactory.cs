//PROJECT NAME: Logistics
//CLASS NAME: ConvertToDomesticFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ConvertToDomesticFactory
	{
		public IConvertToDomestic Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ConvertToDomestic = new Logistics.Vendor.ConvertToDomestic(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iConvertToDomesticExt = timerfactory.Create<Logistics.Vendor.IConvertToDomestic>(_ConvertToDomestic);
			
			return iConvertToDomesticExt;
		}
	}
}
