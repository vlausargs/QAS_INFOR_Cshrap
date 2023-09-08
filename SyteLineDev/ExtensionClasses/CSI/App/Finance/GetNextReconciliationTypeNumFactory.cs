//PROJECT NAME: Finance
//CLASS NAME: GetNextReconciliationTypeNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetNextReconciliationTypeNumFactory
	{
		public IGetNextReconciliationTypeNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextReconciliationTypeNum = new Finance.GetNextReconciliationTypeNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextReconciliationTypeNumExt = timerfactory.Create<Finance.IGetNextReconciliationTypeNum>(_GetNextReconciliationTypeNum);
			
			return iGetNextReconciliationTypeNumExt;
		}
	}
}
