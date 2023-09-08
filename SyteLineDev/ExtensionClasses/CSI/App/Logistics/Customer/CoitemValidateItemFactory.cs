//PROJECT NAME: Logistics
//CLASS NAME: CoitemValidateItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoitemValidateItemFactory
	{
		public ICoitemValidateItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoitemValidateItem = new Logistics.Customer.CoitemValidateItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemValidateItemExt = timerfactory.Create<Logistics.Customer.ICoitemValidateItem>(_CoitemValidateItem);
			
			return iCoitemValidateItemExt;
		}
	}
}
