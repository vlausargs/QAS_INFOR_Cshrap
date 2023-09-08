//PROJECT NAME: Logistics
//CLASS NAME: WirePostVerifyCloseFormFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class WirePostVerifyCloseFormFactory
	{
		public IWirePostVerifyCloseForm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WirePostVerifyCloseForm = new Logistics.Vendor.WirePostVerifyCloseForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWirePostVerifyCloseFormExt = timerfactory.Create<Logistics.Vendor.IWirePostVerifyCloseForm>(_WirePostVerifyCloseForm);
			
			return iWirePostVerifyCloseFormExt;
		}
	}
}
