//PROJECT NAME: Production
//CLASS NAME: ApsJOBSTEPDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsJOBSTEPDelFactory
	{
		public IApsJOBSTEPDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsJOBSTEPDel = new Production.APS.ApsJOBSTEPDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsJOBSTEPDelExt = timerfactory.Create<Production.APS.IApsJOBSTEPDel>(_ApsJOBSTEPDel);
			
			return iApsJOBSTEPDelExt;
		}
	}
}
