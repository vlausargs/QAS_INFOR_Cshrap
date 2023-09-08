//PROJECT NAME: Finance
//CLASS NAME: DeleteBudgetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class DeleteBudgetFactory
	{
		public IDeleteBudget Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteBudget = new Finance.DeleteBudget(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteBudgetExt = timerfactory.Create<Finance.IDeleteBudget>(_DeleteBudget);
			
			return iDeleteBudgetExt;
		}
	}
}
