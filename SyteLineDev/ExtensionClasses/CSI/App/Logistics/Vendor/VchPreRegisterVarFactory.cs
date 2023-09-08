//PROJECT NAME: Logistics
//CLASS NAME: VchPreRegisterVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VchPreRegisterVarFactory
	{
		public IVchPreRegisterVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VchPreRegisterVar = new Logistics.Vendor.VchPreRegisterVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVchPreRegisterVarExt = timerfactory.Create<Logistics.Vendor.IVchPreRegisterVar>(_VchPreRegisterVar);
			
			return iVchPreRegisterVarExt;
		}
	}
}
