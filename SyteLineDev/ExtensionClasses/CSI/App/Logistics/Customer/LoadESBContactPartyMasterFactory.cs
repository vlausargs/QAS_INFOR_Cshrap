//PROJECT NAME: Logistics
//CLASS NAME: LoadESBContactPartyMasterFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class LoadESBContactPartyMasterFactory
	{
		public ILoadESBContactPartyMaster Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBContactPartyMaster = new Logistics.Customer.LoadESBContactPartyMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBContactPartyMasterExt = timerfactory.Create<Logistics.Customer.ILoadESBContactPartyMaster>(_LoadESBContactPartyMaster);
			
			return iLoadESBContactPartyMasterExt;
		}
	}
}
