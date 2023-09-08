//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROInvFactory
	{
		public ISSSFSSROInv Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _SSSFSSROInv = new Logistics.FieldService.Requests.SSSFSSROInv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROInvExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROInv>(_SSSFSSROInv);
			
			return iSSSFSSROInvExt;
		}
	}
}
