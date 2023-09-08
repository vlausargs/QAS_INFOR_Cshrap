//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroPlanTransPostMiscFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroPlanTransPostMiscFactory
	{
		public ISSSFSSroPlanTransPostMisc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSroPlanTransPostMisc = new Logistics.FieldService.Requests.SSSFSSroPlanTransPostMisc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroPlanTransPostMiscExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroPlanTransPostMisc>(_SSSFSSroPlanTransPostMisc);
			
			return iSSSFSSroPlanTransPostMiscExt;
		}
	}
}
