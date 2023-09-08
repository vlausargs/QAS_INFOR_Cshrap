//PROJECT NAME: Data
//CLASS NAME: FmtJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class FmtJobFactory
	{
		public IFmtJob Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var _FmtJob = new FmtJob(appDB);


			return _FmtJob;
		}
	}
}
