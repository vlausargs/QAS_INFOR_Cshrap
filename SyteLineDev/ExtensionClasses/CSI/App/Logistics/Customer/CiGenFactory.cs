//PROJECT NAME: CSICustomer
//CLASS NAME: CiGenFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CiGenFactory
	{
		public ICiGen Create(IApplicationDB appDB)
		{
			var _CiGen = new Logistics.Customer.CiGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCiGenExt = timerfactory.Create<Logistics.Customer.ICiGen>(_CiGen);
			
			return iCiGenExt;
		}
	}
}
