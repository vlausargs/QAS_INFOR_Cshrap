//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSMultiDaySchedulePostFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSMultiDaySchedulePostFactory
	{
		public ISSSFSMultiDaySchedulePost Create(IApplicationDB appDB)
		{
			var _SSSFSMultiDaySchedulePost = new Logistics.FieldService.Partner.SSSFSMultiDaySchedulePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSMultiDaySchedulePostExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSMultiDaySchedulePost>(_SSSFSMultiDaySchedulePost);
			
			return iSSSFSMultiDaySchedulePostExt;
		}
	}
}
