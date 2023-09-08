//PROJECT NAME: Production
//CLASS NAME: CheckCojobCopyBOMFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CheckCojobCopyBOMFactory
	{
		public ICheckCojobCopyBOM Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CheckCojobCopyBOM = new Production.CheckCojobCopyBOM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckCojobCopyBOMExt = timerfactory.Create<Production.ICheckCojobCopyBOM>(_CheckCojobCopyBOM);
			
			return iCheckCojobCopyBOMExt;
		}
	}
}
