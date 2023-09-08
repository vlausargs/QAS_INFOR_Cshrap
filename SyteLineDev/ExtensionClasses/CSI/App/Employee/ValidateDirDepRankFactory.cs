//PROJECT NAME: Employee
//CLASS NAME: ValidateDirDepRankFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class ValidateDirDepRankFactory
	{
		public IValidateDirDepRank Create(IApplicationDB appDB)
		{
			var _ValidateDirDepRank = new Employee.ValidateDirDepRank(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateDirDepRankExt = timerfactory.Create<Employee.IValidateDirDepRank>(_ValidateDirDepRank);
			
			return iValidateDirDepRankExt;
		}
	}
}
