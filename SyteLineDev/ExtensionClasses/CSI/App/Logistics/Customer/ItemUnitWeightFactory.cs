//PROJECT NAME: Logistics
//CLASS NAME: ItemUnitWeightFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ItemUnitWeightFactory
	{
		public IItemUnitWeight Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemUnitWeight = new Logistics.Customer.ItemUnitWeight(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemUnitWeightExt = timerfactory.Create<Logistics.Customer.IItemUnitWeight>(_ItemUnitWeight);
			
			return iItemUnitWeightExt;
		}
	}
}
