//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedApptPostSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedApptPostSaveFactory
	{
		public ISSSFSSchedApptPostSave Create(IApplicationDB appDB)
		{
			var _SSSFSSchedApptPostSave = new Logistics.FieldService.Partner.SSSFSSchedApptPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedApptPostSaveExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedApptPostSave>(_SSSFSSchedApptPostSave);
			
			return iSSSFSSchedApptPostSaveExt;
		}
	}
}
