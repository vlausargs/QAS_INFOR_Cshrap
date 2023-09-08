//PROJECT NAME: Finance
//CLASS NAME: ChkAcctAllFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class ChkAcctAllFactory
	{
		public IChkAcctAll Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ChkAcctAll = new Finance.ChkAcctAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkAcctAllExt = timerfactory.Create<Finance.IChkAcctAll>(_ChkAcctAll);
			
			return iChkAcctAllExt;
		}
	}
}
