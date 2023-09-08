//PROJECT NAME: CSICustomer
//CLASS NAME: InsertEdiParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InsertEdiParmsFactory
	{
		public IInsertEdiParms Create(IApplicationDB appDB)
		{
			var _InsertEdiParms = new Logistics.Customer.InsertEdiParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertEdiParmsExt = timerfactory.Create<Logistics.Customer.IInsertEdiParms>(_InsertEdiParms);
			
			return iInsertEdiParmsExt;
		}
	}
}
