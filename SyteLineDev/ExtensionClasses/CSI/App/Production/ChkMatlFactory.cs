//PROJECT NAME: Production
//CLASS NAME: ChkMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ChkMatlFactory
	{
		public IChkMatl Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ChkMatl = new Production.ChkMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkMatlExt = timerfactory.Create<Production.IChkMatl>(_ChkMatl);
			
			return iChkMatlExt;
		}
	}
}
