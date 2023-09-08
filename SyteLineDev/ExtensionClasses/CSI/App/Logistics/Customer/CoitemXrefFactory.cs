//PROJECT NAME: CSICustomer
//CLASS NAME: CoitemXrefFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemXrefFactory
	{
		public ICoitemXref Create(IApplicationDB appDB)
		{
			var _CoitemXref = new Logistics.Customer.CoitemXref(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemXrefExt = timerfactory.Create<Logistics.Customer.ICoitemXref>(_CoitemXref);
			
			return iCoitemXrefExt;
		}
	}
}
