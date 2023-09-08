//PROJECT NAME: Logistics.Vendor
//CLASS NAME: DoAPAgingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class DoAPAgingFactory
	{
		public IDoAPAging Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _DoAPAging = new Logistics.Vendor.DoAPAging(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDoAPAgingExt = timerfactory.Create<Logistics.Vendor.IDoAPAging>(_DoAPAging);

			return iDoAPAgingExt;
		}
	}
}
