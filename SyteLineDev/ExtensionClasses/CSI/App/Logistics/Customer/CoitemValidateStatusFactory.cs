//PROJECT NAME: Logistics
//CLASS NAME: CoitemValidateStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoitemValidateStatusFactory
	{
		public ICoitemValidateStatus Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoitemValidateStatus = new Logistics.Customer.CoitemValidateStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemValidateStatusExt = timerfactory.Create<Logistics.Customer.ICoitemValidateStatus>(_CoitemValidateStatus);
			
			return iCoitemValidateStatusExt;
		}
	}
}
