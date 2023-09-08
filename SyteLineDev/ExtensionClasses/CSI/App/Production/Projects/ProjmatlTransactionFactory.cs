//PROJECT NAME: Production
//CLASS NAME: ProjmatlTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjmatlTransactionFactory
	{
		public IProjmatlTransaction Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjmatlTransaction = new Production.Projects.ProjmatlTransaction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjmatlTransactionExt = timerfactory.Create<Production.Projects.IProjmatlTransaction>(_ProjmatlTransaction);
			
			return iProjmatlTransactionExt;
		}
	}
}
