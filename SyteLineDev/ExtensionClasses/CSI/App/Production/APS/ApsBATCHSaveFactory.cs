//PROJECT NAME: Production
//CLASS NAME: ApsBATCHSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsBATCHSaveFactory
	{
		public IApsBATCHSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsBATCHSave = new Production.APS.ApsBATCHSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsBATCHSaveExt = timerfactory.Create<Production.APS.IApsBATCHSave>(_ApsBATCHSave);
			
			return iApsBATCHSaveExt;
		}
	}
}
