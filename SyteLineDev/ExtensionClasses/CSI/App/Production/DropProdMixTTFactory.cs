//PROJECT NAME: Production
//CLASS NAME: DropProdMixTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class DropProdMixTTFactory
	{
		public IDropProdMixTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DropProdMixTT = new Production.DropProdMixTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDropProdMixTTExt = timerfactory.Create<Production.IDropProdMixTT>(_DropProdMixTT);
			
			return iDropProdMixTTExt;
		}
	}
}
