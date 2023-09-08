//PROJECT NAME: Codes
//CLASS NAME: SaveInvProceduralMarkingsUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class SaveInvProceduralMarkingsUpdFactory
	{
		public ISaveInvProceduralMarkingsUpd Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _SaveInvProceduralMarkingsUpd = new Codes.SaveInvProceduralMarkingsUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveInvProceduralMarkingsUpdExt = timerfactory.Create<Codes.ISaveInvProceduralMarkingsUpd>(_SaveInvProceduralMarkingsUpd);
			
			return iSaveInvProceduralMarkingsUpdExt;
		}
	}
}
