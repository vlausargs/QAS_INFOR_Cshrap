//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPrparmsCurFlagInfoFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class GetPrparmsCurFlagInfoFactory
	{
		public IGetPrparmsCurFlagInfo Create(IApplicationDB appDB)
		{
			var _GetPrparmsCurFlagInfo = new Employee.GetPrparmsCurFlagInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPrparmsCurFlagInfoExt = timerfactory.Create<Employee.IGetPrparmsCurFlagInfo>(_GetPrparmsCurFlagInfo);
			
			return iGetPrparmsCurFlagInfoExt;
		}
	}
}
