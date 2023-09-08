//PROJECT NAME: Production
//CLASS NAME: EngWBPsSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class EngWBPsSaveFactory
	{
		public IEngWBPsSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EngWBPsSave = new Production.EngWBPsSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBPsSaveExt = timerfactory.Create<Production.IEngWBPsSave>(_EngWBPsSave);
			
			return iEngWBPsSaveExt;
		}
	}
}
