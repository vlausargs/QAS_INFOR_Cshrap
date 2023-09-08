//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoitemValidateQtyOrderedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EdiCoitemValidateQtyOrderedFactory
	{
		public IEdiCoitemValidateQtyOrdered Create(IApplicationDB appDB)
		{
			var _EdiCoitemValidateQtyOrdered = new Logistics.Customer.EdiCoitemValidateQtyOrdered(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEdiCoitemValidateQtyOrderedExt = timerfactory.Create<Logistics.Customer.IEdiCoitemValidateQtyOrdered>(_EdiCoitemValidateQtyOrdered);
			
			return iEdiCoitemValidateQtyOrderedExt;
		}
	}
}
