//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLaborDCFinishFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROLaborDCFinishFactory
	{
		public ISSSFSSROLaborDCFinish Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROLaborDCFinish = new Logistics.FieldService.Requests.SSSFSSROLaborDCFinish(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROLaborDCFinishExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROLaborDCFinish>(_SSSFSSROLaborDCFinish);
			
			return iSSSFSSROLaborDCFinishExt;
		}
	}
}
