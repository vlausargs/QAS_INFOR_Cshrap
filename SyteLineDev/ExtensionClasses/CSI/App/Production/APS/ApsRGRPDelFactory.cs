//PROJECT NAME: Production
//CLASS NAME: ApsRGRPDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsRGRPDelFactory
	{
		public IApsRGRPDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsRGRPDel = new Production.APS.ApsRGRPDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsRGRPDelExt = timerfactory.Create<Production.APS.IApsRGRPDel>(_ApsRGRPDel);
			
			return iApsRGRPDelExt;
		}
	}
}
