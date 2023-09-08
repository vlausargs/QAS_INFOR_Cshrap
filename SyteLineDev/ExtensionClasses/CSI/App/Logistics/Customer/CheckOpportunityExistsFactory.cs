//PROJECT NAME: Logistics
//CLASS NAME: CheckOpportunityExistsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CheckOpportunityExistsFactory
	{
		public ICheckOpportunityExists Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckOpportunityExists = new Logistics.Customer.CheckOpportunityExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckOpportunityExistsExt = timerfactory.Create<Logistics.Customer.ICheckOpportunityExists>(_CheckOpportunityExists);
			
			return iCheckOpportunityExistsExt;
		}
	}
}
