//PROJECT NAME: Finance
//CLASS NAME: AcctDFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class AcctDFactory
	{
		public IAcctD Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AcctD = new Finance.AcctD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAcctDExt = timerfactory.Create<Finance.IAcctD>(_AcctD);
			
			return iAcctDExt;
		}
	}
}
