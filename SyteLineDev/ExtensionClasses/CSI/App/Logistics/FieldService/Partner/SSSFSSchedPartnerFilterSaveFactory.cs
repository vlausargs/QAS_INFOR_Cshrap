//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedPartnerFilterSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedPartnerFilterSaveFactory
	{
		public ISSSFSSchedPartnerFilterSave Create(IApplicationDB appDB)
		{
			var _SSSFSSchedPartnerFilterSave = new Logistics.FieldService.Partner.SSSFSSchedPartnerFilterSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedPartnerFilterSaveExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedPartnerFilterSave>(_SSSFSSchedPartnerFilterSave);
			
			return iSSSFSSchedPartnerFilterSaveExt;
		}
	}
}
