//PROJECT NAME: Config
//CLASS NAME: CfgMapConfigurationDataWriteXMLFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgMapConfigurationDataWriteXMLFactory
	{
		public ICfgMapConfigurationDataWriteXML Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgMapConfigurationDataWriteXML = new Config.CfgMapConfigurationDataWriteXML(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgMapConfigurationDataWriteXMLExt = timerfactory.Create<Config.ICfgMapConfigurationDataWriteXML>(_CfgMapConfigurationDataWriteXML);
			
			return iCfgMapConfigurationDataWriteXMLExt;
		}
	}
}
