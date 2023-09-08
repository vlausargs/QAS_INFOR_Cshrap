//PROJECT NAME: Finance
//CLASS NAME: ReverseTransactionFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ReverseTransactionFactory
	{
		public IReverseTransaction Create(IApplicationDB appDB)
		{
			var _ReverseTransaction = new Finance.ReverseTransaction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReverseTransactionExt = timerfactory.Create<Finance.IReverseTransaction>(_ReverseTransaction);
			
			return iReverseTransactionExt;
		}
	}
}
