//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSWSSchedSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSWSSchedSaveFactory
	{
		public ISSSFSWSSchedSave Create(IApplicationDB appDB)
		{
			var _SSSFSWSSchedSave = new Logistics.FieldService.Partner.SSSFSWSSchedSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSWSSchedSaveExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSWSSchedSave>(_SSSFSWSSchedSave);
			
			return iSSSFSWSSchedSaveExt;
		}
	}
}
