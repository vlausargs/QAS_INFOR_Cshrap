//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedDispatchPartnerSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedDispatchPartnerSaveFactory
	{
		public ISSSFSSchedDispatchPartnerSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSchedDispatchPartnerSave = new Logistics.FieldService.Partner.SSSFSSchedDispatchPartnerSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedDispatchPartnerSaveExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedDispatchPartnerSave>(_SSSFSSchedDispatchPartnerSave);
			
			return iSSSFSSchedDispatchPartnerSaveExt;
		}
	}
}
