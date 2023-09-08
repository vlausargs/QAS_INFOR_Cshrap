//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPrparmsCurInfoFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class GetPrparmsCurInfoFactory
	{
		public IGetPrparmsCurInfo Create(IApplicationDB appDB)
		{
			var _GetPrparmsCurInfo = new Employee.GetPrparmsCurInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPrparmsCurInfoExt = timerfactory.Create<Employee.IGetPrparmsCurInfo>(_GetPrparmsCurInfo);
			
			return iGetPrparmsCurInfoExt;
		}
	}
}
