//PROJECT NAME: Finance
//CLASS NAME: CHSVoucherPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.Chinese
{
	public class CHSVoucherPostFactory
	{
		public ICHSVoucherPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CHSVoucherPost = new Finance.Chinese.CHSVoucherPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSVoucherPostExt = timerfactory.Create<Finance.Chinese.ICHSVoucherPost>(_CHSVoucherPost);
			
			return iCHSVoucherPostExt;
		}
	}
}
