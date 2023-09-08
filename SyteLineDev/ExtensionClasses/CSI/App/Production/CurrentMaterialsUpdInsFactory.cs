//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsUpdInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CurrentMaterialsUpdInsFactory
	{
		public ICurrentMaterialsUpdIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrentMaterialsUpdIns = new Production.CurrentMaterialsUpdIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCurrentMaterialsUpdInsExt = timerfactory.Create<Production.ICurrentMaterialsUpdIns>(_CurrentMaterialsUpdIns);
			
			return iCurrentMaterialsUpdInsExt;
		}
	}
}
