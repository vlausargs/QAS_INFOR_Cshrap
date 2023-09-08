//PROJECT NAME: Finance
//CLASS NAME: AcctRecursiveTestFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class AcctRecursiveTestFactory
	{
		public IAcctRecursiveTest Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AcctRecursiveTest = new Finance.AcctRecursiveTest(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAcctRecursiveTestExt = timerfactory.Create<Finance.IAcctRecursiveTest>(_AcctRecursiveTest);
			
			return iAcctRecursiveTestExt;
		}
	}
}
