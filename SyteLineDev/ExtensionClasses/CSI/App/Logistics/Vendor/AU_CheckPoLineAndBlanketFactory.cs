//PROJECT NAME: Logistics
//CLASS NAME: AU_CheckPoLineAndBlanketFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AU_CheckPoLineAndBlanketFactory
	{
		public IAU_CheckPoLineAndBlanket Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AU_CheckPoLineAndBlanket = new Logistics.Vendor.AU_CheckPoLineAndBlanket(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CheckPoLineAndBlanketExt = timerfactory.Create<Logistics.Vendor.IAU_CheckPoLineAndBlanket>(_AU_CheckPoLineAndBlanket);
			
			return iAU_CheckPoLineAndBlanketExt;
		}
	}
}
