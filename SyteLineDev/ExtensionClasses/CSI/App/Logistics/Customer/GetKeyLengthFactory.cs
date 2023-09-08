//PROJECT NAME: Logistics
//CLASS NAME: GetKeyLengthFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetKeyLengthFactory
	{
		public IGetKeyLength Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetKeyLength = new Logistics.Customer.GetKeyLength(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetKeyLengthExt = timerfactory.Create<Logistics.Customer.IGetKeyLength>(_GetKeyLength);
			
			return iGetKeyLengthExt;
		}
	}
}
