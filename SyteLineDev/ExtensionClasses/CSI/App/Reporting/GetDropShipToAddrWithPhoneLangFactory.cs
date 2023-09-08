//PROJECT NAME: Reporting
//CLASS NAME: GetDropShipToAddrWithPhoneLangFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Reporting
{
	public class GetDropShipToAddrWithPhoneLangFactory
	{
		public IGetDropShipToAddrWithPhoneLang Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			
			var _GetDropShipToAddrWithPhoneLang = new Reporting.GetDropShipToAddrWithPhoneLang(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDropShipToAddrWithPhoneLangExt = timerfactory.Create<Reporting.IGetDropShipToAddrWithPhoneLang>(_GetDropShipToAddrWithPhoneLang);
			
			return iGetDropShipToAddrWithPhoneLangExt;
		}
	}
}
