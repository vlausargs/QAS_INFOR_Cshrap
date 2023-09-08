//PROJECT NAME: Admin
//CLASS NAME: CreatePrivacyUtilityEsigFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class CreatePrivacyUtilityEsigFactory
	{
		public ICreatePrivacyUtilityEsig Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreatePrivacyUtilityEsig = new Admin.CreatePrivacyUtilityEsig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePrivacyUtilityEsigExt = timerfactory.Create<Admin.ICreatePrivacyUtilityEsig>(_CreatePrivacyUtilityEsig);
			
			return iCreatePrivacyUtilityEsigExt;
		}
	}
}
