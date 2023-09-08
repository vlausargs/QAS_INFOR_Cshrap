//PROJECT NAME: Codes
//CLASS NAME: InvProceduralMarkingsUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class InvProceduralMarkingsUpdFactory
	{
		public IInvProceduralMarkingsUpd Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _InvProceduralMarkingsUpd = new Codes.InvProceduralMarkingsUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvProceduralMarkingsUpdExt = timerfactory.Create<Codes.IInvProceduralMarkingsUpd>(_InvProceduralMarkingsUpd);
			
			return iInvProceduralMarkingsUpdExt;
		}
	}
}
