//PROJECT NAME: Config
//CLASS NAME: CopyRoutingBOMPredisplayFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CopyRoutingBOMPredisplayFactory
	{
		public ICopyRoutingBOMPredisplay Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CopyRoutingBOMPredisplay = new Config.CopyRoutingBOMPredisplay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyRoutingBOMPredisplayExt = timerfactory.Create<Config.ICopyRoutingBOMPredisplay>(_CopyRoutingBOMPredisplay);
			
			return iCopyRoutingBOMPredisplayExt;
		}
	}
}
