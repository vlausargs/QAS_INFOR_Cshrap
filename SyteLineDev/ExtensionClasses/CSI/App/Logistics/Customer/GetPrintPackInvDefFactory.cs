//PROJECT NAME: CSICustomer
//CLASS NAME: GetPrintPackInvDefFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetPrintPackInvDefFactory
	{
		public IGetPrintPackInvDef Create(IApplicationDB appDB)
		{
			var _GetPrintPackInvDef = new Logistics.Customer.GetPrintPackInvDef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPrintPackInvDefExt = timerfactory.Create<Logistics.Customer.IGetPrintPackInvDef>(_GetPrintPackInvDef);
			
			return iGetPrintPackInvDefExt;
		}
	}
}
