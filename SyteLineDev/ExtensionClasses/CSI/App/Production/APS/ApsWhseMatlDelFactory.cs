//PROJECT NAME: Production
//CLASS NAME: ApsWhseMatlDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsWhseMatlDelFactory
	{
		public IApsWhseMatlDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsWhseMatlDel = new Production.APS.ApsWhseMatlDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsWhseMatlDelExt = timerfactory.Create<Production.APS.IApsWhseMatlDel>(_ApsWhseMatlDel);
			
			return iApsWhseMatlDelExt;
		}
	}
}
