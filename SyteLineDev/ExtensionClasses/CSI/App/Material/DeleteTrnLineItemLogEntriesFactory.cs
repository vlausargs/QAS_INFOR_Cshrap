//PROJECT NAME: Material
//CLASS NAME: DeleteTrnLineItemLogEntriesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class DeleteTrnLineItemLogEntriesFactory
	{
		public IDeleteTrnLineItemLogEntries Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteTrnLineItemLogEntries = new Material.DeleteTrnLineItemLogEntries(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTrnLineItemLogEntriesExt = timerfactory.Create<Material.IDeleteTrnLineItemLogEntries>(_DeleteTrnLineItemLogEntries);
			
			return iDeleteTrnLineItemLogEntriesExt;
		}
	}
}
