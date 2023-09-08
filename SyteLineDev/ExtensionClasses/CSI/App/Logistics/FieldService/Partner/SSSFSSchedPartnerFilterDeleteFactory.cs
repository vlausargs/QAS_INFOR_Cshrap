//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedPartnerFilterDeleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedPartnerFilterDeleteFactory
	{
		public ISSSFSSchedPartnerFilterDelete Create(IApplicationDB appDB)
		{
			var _SSSFSSchedPartnerFilterDelete = new Logistics.FieldService.Partner.SSSFSSchedPartnerFilterDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedPartnerFilterDeleteExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedPartnerFilterDelete>(_SSSFSSchedPartnerFilterDelete);
			
			return iSSSFSSchedPartnerFilterDeleteExt;
		}
	}
}
