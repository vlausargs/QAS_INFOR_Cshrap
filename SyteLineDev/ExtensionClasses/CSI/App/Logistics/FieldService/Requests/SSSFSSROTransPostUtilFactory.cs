//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransPostUtilFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransPostUtilFactory
	{
		public ISSSFSSROTransPostUtil Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransPostUtil = new Logistics.FieldService.Requests.SSSFSSROTransPostUtil(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransPostUtilExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransPostUtil>(_SSSFSSROTransPostUtil);
			
			return iSSSFSSROTransPostUtilExt;
		}
	}
}
