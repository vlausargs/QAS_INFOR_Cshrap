//PROJECT NAME: Codes
//CLASS NAME: GetFileServerPropertyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GetFileServerPropertyFactory
	{
		public IGetFileServerProperty Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetFileServerProperty = new Codes.GetFileServerProperty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFileServerPropertyExt = timerfactory.Create<Codes.IGetFileServerProperty>(_GetFileServerProperty);
			
			return iGetFileServerPropertyExt;
		}
	}
}
