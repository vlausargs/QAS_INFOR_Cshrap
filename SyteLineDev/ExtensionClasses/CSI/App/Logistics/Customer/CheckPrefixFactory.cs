//PROJECT NAME: Logistics
//CLASS NAME: CheckPrefixFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CheckPrefixFactory
	{
		public ICheckPrefix Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckPrefix = new Logistics.Customer.CheckPrefix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckPrefixExt = timerfactory.Create<Logistics.Customer.ICheckPrefix>(_CheckPrefix);
			
			return iCheckPrefixExt;
		}
	}
}
