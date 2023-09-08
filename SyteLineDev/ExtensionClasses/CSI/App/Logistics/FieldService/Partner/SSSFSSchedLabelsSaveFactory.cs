//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedLabelsSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedLabelsSaveFactory
	{
		public ISSSFSSchedLabelsSave Create(IApplicationDB appDB)
		{
			var _SSSFSSchedLabelsSave = new Logistics.FieldService.Partner.SSSFSSchedLabelsSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedLabelsSaveExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedLabelsSave>(_SSSFSSchedLabelsSave);
			
			return iSSSFSSchedLabelsSaveExt;
		}
	}
}
