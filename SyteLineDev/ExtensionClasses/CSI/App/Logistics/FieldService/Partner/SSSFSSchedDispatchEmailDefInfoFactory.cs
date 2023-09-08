//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedDispatchEmailDefInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedDispatchEmailDefInfoFactory
	{
		public ISSSFSSchedDispatchEmailDefInfo Create(IApplicationDB appDB)
		{
			var _SSSFSSchedDispatchEmailDefInfo = new Logistics.FieldService.Partner.SSSFSSchedDispatchEmailDefInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedDispatchEmailDefInfoExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedDispatchEmailDefInfo>(_SSSFSSchedDispatchEmailDefInfo);
			
			return iSSSFSSchedDispatchEmailDefInfoExt;
		}
	}
}
