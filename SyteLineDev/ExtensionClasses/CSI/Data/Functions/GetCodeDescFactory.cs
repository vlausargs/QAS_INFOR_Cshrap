//PROJECT NAME: Data
//CLASS NAME: GetCodeDescFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class GetCodeDescFactory
	{
		public IGetCodeDesc Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var _GetCodeDesc = new Functions.GetCodeDesc(appDB);


			return _GetCodeDesc;
		}
	}
}
