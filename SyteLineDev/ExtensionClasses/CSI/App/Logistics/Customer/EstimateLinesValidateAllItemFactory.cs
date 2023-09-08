//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesValidateAllItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesValidateAllItemFactory
	{
		public IEstimateLinesValidateAllItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstimateLinesValidateAllItem = new Logistics.Customer.EstimateLinesValidateAllItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateLinesValidateAllItemExt = timerfactory.Create<Logistics.Customer.IEstimateLinesValidateAllItem>(_EstimateLinesValidateAllItem);
			
			return iEstimateLinesValidateAllItemExt;
		}
	}
}
