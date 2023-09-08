//PROJECT NAME: Codes
//CLASS NAME: IdentifyCustomerPortalUserTypeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class IdentifyCustomerPortalUserTypeFactory
	{
		public IIdentifyCustomerPortalUserType Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IdentifyCustomerPortalUserType = new Codes.IdentifyCustomerPortalUserType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIdentifyCustomerPortalUserTypeExt = timerfactory.Create<Codes.IIdentifyCustomerPortalUserType>(_IdentifyCustomerPortalUserType);
			
			return iIdentifyCustomerPortalUserTypeExt;
		}
	}
}
