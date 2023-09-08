//PROJECT NAME: Production
//CLASS NAME: ApsBATPRODDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsBATPRODDelFactory
	{
		public IApsBATPRODDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsBATPRODDel = new Production.APS.ApsBATPRODDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsBATPRODDelExt = timerfactory.Create<Production.APS.IApsBATPRODDel>(_ApsBATPRODDel);
			
			return iApsBATPRODDelExt;
		}
	}
}
