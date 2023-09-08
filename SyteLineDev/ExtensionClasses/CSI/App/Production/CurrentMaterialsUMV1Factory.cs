//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsUMV1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CurrentMaterialsUMV1Factory
	{
		public ICurrentMaterialsUMV1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrentMaterialsUMV1 = new Production.CurrentMaterialsUMV1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCurrentMaterialsUMV1Ext = timerfactory.Create<Production.ICurrentMaterialsUMV1>(_CurrentMaterialsUMV1);
			
			return iCurrentMaterialsUMV1Ext;
		}
	}
}
