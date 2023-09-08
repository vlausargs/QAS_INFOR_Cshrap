//PROJECT NAME: Logistics
//CLASS NAME: SetCoStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class SetCoStatusFactory
	{
		public ISetCoStatus Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SetCoStatus = new Logistics.Customer.SetCoStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetCoStatusExt = timerfactory.Create<Logistics.Customer.ISetCoStatus>(_SetCoStatus);
			
			return iSetCoStatusExt;
		}
	}
}
