//PROJECT NAME: Data
//CLASS NAME: UserCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class UserCodeFactory
	{
		public IUserCode Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var _UserCode = new Codes.UserCode(appDB);

			return _UserCode;
		}
	}
}
