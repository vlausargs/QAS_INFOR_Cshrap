//PROJECT NAME: Logistics
//CLASS NAME: GetExchRate2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetExchRate2Factory
	{
		public IGetExchRate2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetExchRate2 = new Logistics.Customer.GetExchRate2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetExchRate2Ext = timerfactory.Create<Logistics.Customer.IGetExchRate2>(_GetExchRate2);
			
			return iGetExchRate2Ext;
		}
	}
}
