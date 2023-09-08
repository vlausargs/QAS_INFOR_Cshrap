//PROJECT NAME: Codes
//CLASS NAME: ConvDateWithFormatNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class ConvDateWithFormatNumberFactory
	{
		public IConvDateWithFormatNumber Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ConvDateWithFormatNumber = new Codes.ConvDateWithFormatNumber(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iConvDateWithFormatNumberExt = timerfactory.Create<Codes.IConvDateWithFormatNumber>(_ConvDateWithFormatNumber);
			
			return iConvDateWithFormatNumberExt;
		}
	}
}
