//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransSetItemPriceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransSetItemPriceFactory
	{
		public ISSSFSSROTransSetItemPrice Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransSetItemPrice = new Logistics.FieldService.Requests.SSSFSSROTransSetItemPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransSetItemPriceExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransSetItemPrice>(_SSSFSSROTransSetItemPrice);
			
			return iSSSFSSROTransSetItemPriceExt;
		}
	}
}
