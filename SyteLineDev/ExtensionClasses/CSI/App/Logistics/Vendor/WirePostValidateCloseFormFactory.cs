//PROJECT NAME: Logistics
//CLASS NAME: WirePostValidateCloseFormFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class WirePostValidateCloseFormFactory
	{
		public IWirePostValidateCloseForm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WirePostValidateCloseForm = new Logistics.Vendor.WirePostValidateCloseForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWirePostValidateCloseFormExt = timerfactory.Create<Logistics.Vendor.IWirePostValidateCloseForm>(_WirePostValidateCloseForm);
			
			return iWirePostValidateCloseFormExt;
		}
	}
}
