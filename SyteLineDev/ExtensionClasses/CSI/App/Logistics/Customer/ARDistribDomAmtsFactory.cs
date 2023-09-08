//PROJECT NAME: Logistics
//CLASS NAME: ARDistribDomAmtsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARDistribDomAmtsFactory
	{
		public IARDistribDomAmts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARDistribDomAmts = new Logistics.Customer.ARDistribDomAmts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARDistribDomAmtsExt = timerfactory.Create<Logistics.Customer.IARDistribDomAmts>(_ARDistribDomAmts);
			
			return iARDistribDomAmtsExt;
		}
	}
}
