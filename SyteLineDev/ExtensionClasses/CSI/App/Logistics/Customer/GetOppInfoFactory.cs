//PROJECT NAME: Logistics
//CLASS NAME: GetOppInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetOppInfoFactory
	{
		public IGetOppInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetOppInfo = new Logistics.Customer.GetOppInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetOppInfoExt = timerfactory.Create<Logistics.Customer.IGetOppInfo>(_GetOppInfo);
			
			return iGetOppInfoExt;
		}
	}
}
