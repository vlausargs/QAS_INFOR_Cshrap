//PROJECT NAME: Finance
//CLASS NAME: CHSCheckVoucherFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.Chinese
{
	public class CHSCheckVoucherFactory
	{
		public ICHSCheckVoucher Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CHSCheckVoucher = new Finance.Chinese.CHSCheckVoucher(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSCheckVoucherExt = timerfactory.Create<Finance.Chinese.ICHSCheckVoucher>(_CHSCheckVoucher);
			
			return iCHSCheckVoucherExt;
		}
	}
}
