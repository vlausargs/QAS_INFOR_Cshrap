//PROJECT NAME: Production
//CLASS NAME: CtcLogCreateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class CtcLogCreateFactory
	{
		public ICtcLogCreate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CtcLogCreate = new Production.Projects.CtcLogCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCtcLogCreateExt = timerfactory.Create<Production.Projects.ICtcLogCreate>(_CtcLogCreate);
			
			return iCtcLogCreateExt;
		}
	}
}
