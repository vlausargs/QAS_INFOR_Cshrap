//PROJECT NAME: Codes
//CLASS NAME: EuroInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class EuroInfoFactory
	{
		public IEuroInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EuroInfo = new Codes.EuroInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEuroInfoExt = timerfactory.Create<Codes.IEuroInfo>(_EuroInfo);
			
			return iEuroInfoExt;
		}
	}
}
