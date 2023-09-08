//PROJECT NAME: Finance
//CLASS NAME: CHSGenRecurrVoucherFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.Chinese
{
	public class CHSGenRecurrVoucherFactory
	{
		public ICHSGenRecurrVoucher Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CHSGenRecurrVoucher = new Finance.Chinese.CHSGenRecurrVoucher(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSGenRecurrVoucherExt = timerfactory.Create<Finance.Chinese.ICHSGenRecurrVoucher>(_CHSGenRecurrVoucher);
			
			return iCHSGenRecurrVoucherExt;
		}
	}
}
