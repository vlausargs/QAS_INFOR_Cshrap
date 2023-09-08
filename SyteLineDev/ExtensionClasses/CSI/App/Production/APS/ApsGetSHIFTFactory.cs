//PROJECT NAME: Production
//CLASS NAME: ApsGetSHIFTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsGetSHIFTFactory
	{
		public IApsGetSHIFT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsGetSHIFT = new Production.APS.ApsGetSHIFT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsGetSHIFTExt = timerfactory.Create<Production.APS.IApsGetSHIFT>(_ApsGetSHIFT);
			
			return iApsGetSHIFTExt;
		}
	}
}
