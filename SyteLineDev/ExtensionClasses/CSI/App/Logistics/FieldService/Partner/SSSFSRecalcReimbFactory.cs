//PROJECT NAME: Logistics
//CLASS NAME: SSSFSRecalcReimbFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSRecalcReimbFactory
	{
		public ISSSFSRecalcReimb Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _SSSFSRecalcReimb = new Logistics.FieldService.Partner.SSSFSRecalcReimb(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRecalcReimbExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSRecalcReimb>(_SSSFSRecalcReimb);
			
			return iSSSFSRecalcReimbExt;
		}
	}
}
