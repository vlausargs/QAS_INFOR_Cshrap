//PROJECT NAME: Logistics
//CLASS NAME: GetEcvtItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetEcvtItemFactory
	{
		public IGetEcvtItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetEcvtItem = new Logistics.Customer.GetEcvtItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetEcvtItemExt = timerfactory.Create<Logistics.Customer.IGetEcvtItem>(_GetEcvtItem);
			
			return iGetEcvtItemExt;
		}
	}
}
