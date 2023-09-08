//PROJECT NAME: Production
//CLASS NAME: MO_ResourceDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class MO_ResourceDelFactory
	{
		public IMO_ResourceDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_ResourceDel = new Production.APS.MO_ResourceDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_ResourceDelExt = timerfactory.Create<Production.APS.IMO_ResourceDel>(_MO_ResourceDel);
			
			return iMO_ResourceDelExt;
		}
	}
}
