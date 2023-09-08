//PROJECT NAME: Employee
//CLASS NAME: VerifyPrtrxChecksToPrintPostFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class VerifyPrtrxChecksToPrintPostFactory
	{
		public IVerifyPrtrxChecksToPrintPost Create(IApplicationDB appDB)
		{
			var _VerifyPrtrxChecksToPrintPost = new Employee.VerifyPrtrxChecksToPrintPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyPrtrxChecksToPrintPostExt = timerfactory.Create<Employee.IVerifyPrtrxChecksToPrintPost>(_VerifyPrtrxChecksToPrintPost);
			
			return iVerifyPrtrxChecksToPrintPostExt;
		}
	}
}
