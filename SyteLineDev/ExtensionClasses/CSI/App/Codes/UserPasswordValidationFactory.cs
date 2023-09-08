//PROJECT NAME: Codes
//CLASS NAME: UserPasswordValidationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class UserPasswordValidationFactory
	{
		public IUserPasswordValidation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UserPasswordValidation = new Codes.UserPasswordValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUserPasswordValidationExt = timerfactory.Create<Codes.IUserPasswordValidation>(_UserPasswordValidation);
			
			return iUserPasswordValidationExt;
		}
	}
}
