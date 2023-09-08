//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesValidateItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesValidateItemFactory
	{
		public IEstimateLinesValidateItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstimateLinesValidateItem = new Logistics.Customer.EstimateLinesValidateItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateLinesValidateItemExt = timerfactory.Create<Logistics.Customer.IEstimateLinesValidateItem>(_EstimateLinesValidateItem);
			
			return iEstimateLinesValidateItemExt;
		}
	}
}
