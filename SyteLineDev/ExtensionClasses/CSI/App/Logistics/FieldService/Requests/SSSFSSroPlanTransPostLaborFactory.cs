//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroPlanTransPostLaborFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroPlanTransPostLaborFactory
	{
		public ISSSFSSroPlanTransPostLabor Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSroPlanTransPostLabor = new Logistics.FieldService.Requests.SSSFSSroPlanTransPostLabor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroPlanTransPostLaborExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroPlanTransPostLabor>(_SSSFSSroPlanTransPostLabor);
			
			return iSSSFSSroPlanTransPostLaborExt;
		}
	}
}
