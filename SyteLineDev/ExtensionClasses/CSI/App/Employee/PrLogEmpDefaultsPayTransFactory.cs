//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogEmpDefaultsPayTransFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PrLogEmpDefaultsPayTransFactory
	{
		public IPrLogEmpDefaultsPayTrans Create(IApplicationDB appDB)
		{
			var _PrLogEmpDefaultsPayTrans = new Employee.PrLogEmpDefaultsPayTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrLogEmpDefaultsPayTransExt = timerfactory.Create<Employee.IPrLogEmpDefaultsPayTrans>(_PrLogEmpDefaultsPayTrans);
			
			return iPrLogEmpDefaultsPayTransExt;
		}
	}
}
