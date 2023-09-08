//PROJECT NAME: Codes
//CLASS NAME: VatProceduralMarkingDefaultsUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class VatProceduralMarkingDefaultsUpdFactory
	{
		public IVatProceduralMarkingDefaultsUpd Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _VatProceduralMarkingDefaultsUpd = new Codes.VatProceduralMarkingDefaultsUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVatProceduralMarkingDefaultsUpdExt = timerfactory.Create<Codes.IVatProceduralMarkingDefaultsUpd>(_VatProceduralMarkingDefaultsUpd);
			
			return iVatProceduralMarkingDefaultsUpdExt;
		}
	}
}
