//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContLineGetItemRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContLineGetItemRateFactory
	{
		public ISSSFSContLineGetItemRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSContLineGetItemRate = new Logistics.FieldService.SSSFSContLineGetItemRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContLineGetItemRateExt = timerfactory.Create<Logistics.FieldService.ISSSFSContLineGetItemRate>(_SSSFSContLineGetItemRate);
			
			return iSSSFSContLineGetItemRateExt;
		}
	}
}
