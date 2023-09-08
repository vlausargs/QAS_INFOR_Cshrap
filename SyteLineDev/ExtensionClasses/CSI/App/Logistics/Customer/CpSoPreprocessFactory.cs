//PROJECT NAME: CSICustomer
//CLASS NAME: CpSoPreprocessFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoPreprocessFactory
	{
		public ICpSoPreprocess Create(IApplicationDB appDB)
		{
			var _CpSoPreprocess = new Logistics.Customer.CpSoPreprocess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCpSoPreprocessExt = timerfactory.Create<Logistics.Customer.ICpSoPreprocess>(_CpSoPreprocess);
			
			return iCpSoPreprocessExt;
		}
	}
}
