//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsItemChgFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CurrentMaterialsItemChgFactory
	{
		public ICurrentMaterialsItemChg Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrentMaterialsItemChg = new Production.CurrentMaterialsItemChg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCurrentMaterialsItemChgExt = timerfactory.Create<Production.ICurrentMaterialsItemChg>(_CurrentMaterialsItemChg);
			
			return iCurrentMaterialsItemChgExt;
		}
	}
}
