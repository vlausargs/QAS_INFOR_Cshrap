//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValidSROMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransValidSROMatlFactory
	{
		public ISSSFSSROTransValidSROMatl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransValidSROMatl = new Logistics.FieldService.Requests.SSSFSSROTransValidSROMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransValidSROMatlExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransValidSROMatl>(_SSSFSSROTransValidSROMatl);
			
			return iSSSFSSROTransValidSROMatlExt;
		}
	}
}
