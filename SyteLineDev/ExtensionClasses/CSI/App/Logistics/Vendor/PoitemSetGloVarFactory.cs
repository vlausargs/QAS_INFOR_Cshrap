//PROJECT NAME: Logistics
//CLASS NAME: PoitemSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoitemSetGloVarFactory
	{
		public IPoitemSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoitemSetGloVar = new Logistics.Vendor.PoitemSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoitemSetGloVarExt = timerfactory.Create<Logistics.Vendor.IPoitemSetGloVar>(_PoitemSetGloVar);
			
			return iPoitemSetGloVarExt;
		}
	}
}
