//PROJECT NAME: Production
//CLASS NAME: PreSaveBatchOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PreSaveBatchOperFactory
	{
		public IPreSaveBatchOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreSaveBatchOper = new Production.PreSaveBatchOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreSaveBatchOperExt = timerfactory.Create<Production.IPreSaveBatchOper>(_PreSaveBatchOper);
			
			return iPreSaveBatchOperExt;
		}
	}
}
