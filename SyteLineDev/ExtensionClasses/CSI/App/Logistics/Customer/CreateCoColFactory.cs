//PROJECT NAME: CSICustomer
//CLASS NAME: CreateCoColFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateCoColFactory
	{
		public ICreateCoCol Create(IApplicationDB appDB)
		{
			var _CreateCoCol = new Logistics.Customer.CreateCoCol(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateCoColExt = timerfactory.Create<Logistics.Customer.ICreateCoCol>(_CreateCoCol);
			
			return iCreateCoColExt;
		}
	}
}
