//PROJECT NAME: Production
//CLASS NAME: ProjNextKeyDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjNextKeyDelFactory
	{
		public IProjNextKeyDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjNextKeyDel = new Production.Projects.ProjNextKeyDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjNextKeyDelExt = timerfactory.Create<Production.Projects.IProjNextKeyDel>(_ProjNextKeyDel);
			
			return iProjNextKeyDelExt;
		}
	}
}
