//PROJECT NAME: Codes
//CLASS NAME: HorizonPostSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class HorizonPostSaveFactory
	{
		public IHorizonPostSave Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _HorizonPostSave = new Codes.HorizonPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHorizonPostSaveExt = timerfactory.Create<Codes.IHorizonPostSave>(_HorizonPostSave);
			
			return iHorizonPostSaveExt;
		}
	}
}
