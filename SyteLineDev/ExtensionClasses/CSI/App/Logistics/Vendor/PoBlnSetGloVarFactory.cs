//PROJECT NAME: Logistics
//CLASS NAME: PoBlnSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoBlnSetGloVarFactory
	{
		public IPoBlnSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoBlnSetGloVar = new Logistics.Vendor.PoBlnSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoBlnSetGloVarExt = timerfactory.Create<Logistics.Vendor.IPoBlnSetGloVar>(_PoBlnSetGloVar);
			
			return iPoBlnSetGloVarExt;
		}
	}
}
