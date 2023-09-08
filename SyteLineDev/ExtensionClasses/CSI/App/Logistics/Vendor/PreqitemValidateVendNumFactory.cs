//PROJECT NAME: Logistics
//CLASS NAME: PreqitemValidateVendNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PreqitemValidateVendNumFactory
	{
		public IPreqitemValidateVendNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreqitemValidateVendNum = new Logistics.Vendor.PreqitemValidateVendNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreqitemValidateVendNumExt = timerfactory.Create<Logistics.Vendor.IPreqitemValidateVendNum>(_PreqitemValidateVendNum);
			
			return iPreqitemValidateVendNumExt;
		}
	}
}
