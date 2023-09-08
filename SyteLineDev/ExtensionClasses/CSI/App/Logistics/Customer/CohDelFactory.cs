//PROJECT NAME: CSICustomer
//CLASS NAME: CohDelFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CohDelFactory
	{
		public ICohDel Create(IApplicationDB appDB)
		{
			var _CohDel = new Logistics.Customer.CohDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCohDelExt = timerfactory.Create<Logistics.Customer.ICohDel>(_CohDel);
			
			return iCohDelExt;
		}
	}
}
