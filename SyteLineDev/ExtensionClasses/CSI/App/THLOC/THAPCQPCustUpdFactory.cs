//PROJECT NAME: THLOC
//CLASS NAME: THAPCQPCustUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.THLOC
{
	public class THAPCQPCustUpdFactory
	{
		public ITHAPCQPCustUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _THAPCQPCustUpd = new THLOC.THAPCQPCustUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHAPCQPCustUpdExt = timerfactory.Create<THLOC.ITHAPCQPCustUpd>(_THAPCQPCustUpd);
			
			return iTHAPCQPCustUpdExt;
		}
	}
}
