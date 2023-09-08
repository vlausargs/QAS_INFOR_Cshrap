//PROJECT NAME: Production
//CLASS NAME: ClrXrefBulkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ClrXrefBulkFactory
	{
		public IClrXrefBulk Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var _ClrXrefBulk = new Production.ClrXrefBulk(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iClrXrefBulkExt = timerfactory.Create<Production.IClrXrefBulk>(_ClrXrefBulk);

			return iClrXrefBulkExt;
		}
	}
}
