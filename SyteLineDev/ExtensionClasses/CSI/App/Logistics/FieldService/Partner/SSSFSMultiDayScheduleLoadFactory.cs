//PROJECT NAME: Logistics
//CLASS NAME: SSSFSMultiDayScheduleLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSMultiDayScheduleLoadFactory
	{
		public ISSSFSMultiDayScheduleLoad Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSMultiDayScheduleLoad = new Logistics.FieldService.Partner.SSSFSMultiDayScheduleLoad(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSMultiDayScheduleLoadExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSMultiDayScheduleLoad>(_SSSFSMultiDayScheduleLoad);
			
			return iSSSFSMultiDayScheduleLoadExt;
		}
	}
}
