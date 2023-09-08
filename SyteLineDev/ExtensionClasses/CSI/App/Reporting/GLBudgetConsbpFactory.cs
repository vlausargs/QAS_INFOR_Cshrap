//PROJECT NAME: Reporting
//CLASS NAME: GLBudgetConsbpFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class GLBudgetConsbpFactory
	{
		public IGLBudgetConsbp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GLBudgetConsbp = new Reporting.GLBudgetConsbp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGLBudgetConsbpExt = timerfactory.Create<Reporting.IGLBudgetConsbp>(_GLBudgetConsbp);
			
			return iGLBudgetConsbpExt;
		}
	}
}
