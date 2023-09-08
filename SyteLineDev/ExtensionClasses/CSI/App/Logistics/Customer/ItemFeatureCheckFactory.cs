//PROJECT NAME: Logistics
//CLASS NAME: ItemFeatureCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ItemFeatureCheckFactory
	{
		public IItemFeatureCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemFeatureCheck = new Logistics.Customer.ItemFeatureCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemFeatureCheckExt = timerfactory.Create<Logistics.Customer.IItemFeatureCheck>(_ItemFeatureCheck);
			
			return iItemFeatureCheckExt;
		}
	}
}
