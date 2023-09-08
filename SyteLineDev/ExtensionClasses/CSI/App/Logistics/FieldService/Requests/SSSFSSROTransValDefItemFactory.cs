//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValDefItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransValDefItemFactory
	{
		public ISSSFSSROTransValDefItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSSROTransValDefItem = new Logistics.FieldService.Requests.SSSFSSROTransValDefItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransValDefItemExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransValDefItem>(_SSSFSSROTransValDefItem);
			
			return iSSSFSSROTransValDefItemExt;
		}
	}
}
