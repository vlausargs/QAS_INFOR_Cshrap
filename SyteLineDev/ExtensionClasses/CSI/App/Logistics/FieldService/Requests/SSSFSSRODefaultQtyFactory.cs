//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSRODefaultQtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSRODefaultQtyFactory
	{
		public ISSSFSSRODefaultQty Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSRODefaultQty = new Logistics.FieldService.Requests.SSSFSSRODefaultQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSRODefaultQtyExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSRODefaultQty>(_SSSFSSRODefaultQty);
			
			return iSSSFSSRODefaultQtyExt;
		}
	}
}
