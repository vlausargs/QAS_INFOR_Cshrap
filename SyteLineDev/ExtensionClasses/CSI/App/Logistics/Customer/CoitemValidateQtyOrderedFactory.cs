//PROJECT NAME: Logistics
//CLASS NAME: CoitemValidateQtyOrderedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoitemValidateQtyOrderedFactory
	{
		public ICoitemValidateQtyOrdered Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoitemValidateQtyOrdered = new Logistics.Customer.CoitemValidateQtyOrdered(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemValidateQtyOrderedExt = timerfactory.Create<Logistics.Customer.ICoitemValidateQtyOrdered>(_CoitemValidateQtyOrdered);
			
			return iCoitemValidateQtyOrderedExt;
		}
	}
}
