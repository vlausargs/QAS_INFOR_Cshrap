//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedLabelsINITFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedLabelsINITFactory
	{
		public ISSSFSSchedLabelsINIT Create(IApplicationDB appDB)
		{
			var _SSSFSSchedLabelsINIT = new Logistics.FieldService.Partner.SSSFSSchedLabelsINIT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedLabelsINITExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedLabelsINIT>(_SSSFSSchedLabelsINIT);
			
			return iSSSFSSchedLabelsINITExt;
		}
	}
}
