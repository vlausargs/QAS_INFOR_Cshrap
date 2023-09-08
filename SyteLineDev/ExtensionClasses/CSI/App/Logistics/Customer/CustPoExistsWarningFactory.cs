//PROJECT NAME: Logistics
//CLASS NAME: CustPoExistsWarningFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustPoExistsWarningFactory
	{
		public ICustPoExistsWarning Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustPoExistsWarning = new Logistics.Customer.CustPoExistsWarning(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustPoExistsWarningExt = timerfactory.Create<Logistics.Customer.ICustPoExistsWarning>(_CustPoExistsWarning);
			
			return iCustPoExistsWarningExt;
		}
	}
}
