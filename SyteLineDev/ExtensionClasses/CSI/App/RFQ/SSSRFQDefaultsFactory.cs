//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQDefaultsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.RFQ
{
	public class SSSRFQDefaultsFactory
	{
		public ISSSRFQDefaults Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSRFQDefaults = new RFQ.SSSRFQDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQDefaultsExt = timerfactory.Create<RFQ.ISSSRFQDefaults>(_SSSRFQDefaults);
			
			return iSSSRFQDefaultsExt;
		}
	}
}
