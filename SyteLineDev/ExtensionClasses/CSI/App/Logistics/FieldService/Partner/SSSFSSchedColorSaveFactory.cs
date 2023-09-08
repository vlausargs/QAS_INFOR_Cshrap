//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedColorSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedColorSaveFactory
	{
		public ISSSFSSchedColorSave Create(IApplicationDB appDB)
		{
			var _SSSFSSchedColorSave = new Logistics.FieldService.Partner.SSSFSSchedColorSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedColorSaveExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedColorSave>(_SSSFSSchedColorSave);
			
			return iSSSFSSchedColorSaveExt;
		}
	}
}
