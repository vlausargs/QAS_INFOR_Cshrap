//PROJECT NAME: Codes
//CLASS NAME: VchProceduralMarkingsUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class VchProceduralMarkingsUpdFactory
	{
		public IVchProceduralMarkingsUpd Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _VchProceduralMarkingsUpd = new Codes.VchProceduralMarkingsUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVchProceduralMarkingsUpdExt = timerfactory.Create<Codes.IVchProceduralMarkingsUpd>(_VchProceduralMarkingsUpd);
			
			return iVchProceduralMarkingsUpdExt;
		}
	}
}
