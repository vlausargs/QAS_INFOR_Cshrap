//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsBomSeqV1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CurrentMaterialsBomSeqV1Factory
	{
		public ICurrentMaterialsBomSeqV1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrentMaterialsBomSeqV1 = new Production.CurrentMaterialsBomSeqV1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCurrentMaterialsBomSeqV1Ext = timerfactory.Create<Production.ICurrentMaterialsBomSeqV1>(_CurrentMaterialsBomSeqV1);
			
			return iCurrentMaterialsBomSeqV1Ext;
		}
	}
}
