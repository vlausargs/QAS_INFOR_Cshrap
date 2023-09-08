//PROJECT NAME: Finance
//CLASS NAME: ChkAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class ChkAcctFactory
	{
		public IChkAcct Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ChkAcct = new Finance.ChkAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkAcctExt = timerfactory.Create<Finance.IChkAcct>(_ChkAcct);
			
			return iChkAcctExt;
		}
	}
}
