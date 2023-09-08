//PROJECT NAME: Production
//CLASS NAME: ApsBATCHDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsBATCHDelFactory
	{
		public IApsBATCHDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsBATCHDel = new Production.APS.ApsBATCHDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsBATCHDelExt = timerfactory.Create<Production.APS.IApsBATCHDel>(_ApsBATCHDel);
			
			return iApsBATCHDelExt;
		}
	}
}
