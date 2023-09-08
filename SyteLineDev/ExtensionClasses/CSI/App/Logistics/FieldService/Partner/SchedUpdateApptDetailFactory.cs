//PROJECT NAME: Logistics
//CLASS NAME: SchedUpdateApptDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedUpdateApptDetailFactory
	{
		public ISchedUpdateApptDetail Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SchedUpdateApptDetail = new Logistics.FieldService.Partner.SchedUpdateApptDetail(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedUpdateApptDetailExt = timerfactory.Create<Logistics.FieldService.Partner.ISchedUpdateApptDetail>(_SchedUpdateApptDetail);
			
			return iSchedUpdateApptDetailExt;
		}
	}
}
