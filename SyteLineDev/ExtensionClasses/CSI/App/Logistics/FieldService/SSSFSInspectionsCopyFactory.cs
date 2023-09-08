//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSInspectionsCopyFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSInspectionsCopyFactory
	{
		public ISSSFSInspectionsCopy Create(IApplicationDB appDB)
		{
			var _SSSFSInspectionsCopy = new Logistics.FieldService.SSSFSInspectionsCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSInspectionsCopyExt = timerfactory.Create<Logistics.FieldService.ISSSFSInspectionsCopy>(_SSSFSInspectionsCopy);
			
			return iSSSFSInspectionsCopyExt;
		}
	}
}
