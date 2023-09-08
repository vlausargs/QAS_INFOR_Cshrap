//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroPlanTransPostMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroPlanTransPostMatlFactory
	{
		public ISSSFSSroPlanTransPostMatl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSroPlanTransPostMatl = new Logistics.FieldService.Requests.SSSFSSroPlanTransPostMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroPlanTransPostMatlExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroPlanTransPostMatl>(_SSSFSSroPlanTransPostMatl);
			
			return iSSSFSSroPlanTransPostMatlExt;
		}
	}
}
