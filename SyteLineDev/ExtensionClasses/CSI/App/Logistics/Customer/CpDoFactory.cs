//PROJECT NAME: CSICustomer
//CLASS NAME: CpDoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpDoFactory
	{
		public ICpDo Create(IApplicationDB appDB)
		{
			var _CpDo = new Logistics.Customer.CpDo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCpDoExt = timerfactory.Create<Logistics.Customer.ICpDo>(_CpDo);
			
			return iCpDoExt;
		}
	}
}
