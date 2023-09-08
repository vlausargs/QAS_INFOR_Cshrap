//PROJECT NAME: Production
//CLASS NAME: CopyBomDoProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CopyBomDoProcessFactory
	{
		public ICopyBomDoProcess Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CopyBomDoProcess = new Production.CopyBomDoProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomDoProcessExt = timerfactory.Create<Production.ICopyBomDoProcess>(_CopyBomDoProcess);
			
			return iCopyBomDoProcessExt;
		}
	}
}
