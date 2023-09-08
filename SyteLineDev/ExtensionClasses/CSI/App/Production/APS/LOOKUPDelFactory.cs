//PROJECT NAME: Production
//CLASS NAME: LOOKUPDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class LOOKUPDelFactory
	{
		public ILOOKUPDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LOOKUPDel = new Production.APS.LOOKUPDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLOOKUPDelExt = timerfactory.Create<Production.APS.ILOOKUPDel>(_LOOKUPDel);
			
			return iLOOKUPDelExt;
		}
	}
}
