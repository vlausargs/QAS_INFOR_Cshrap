//PROJECT NAME: Finance
//CLASS NAME: SSSCCIARPayFromTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIARPayFromTransFactory
	{
		public ISSSCCIARPayFromTrans Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var _SSSCCIARPayFromTrans = new Finance.CreditCard.SSSCCIARPayFromTrans(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIARPayFromTransExt = timerfactory.Create<Finance.CreditCard.ISSSCCIARPayFromTrans>(_SSSCCIARPayFromTrans);

			return iSSSCCIARPayFromTransExt;
		}
	}
}
