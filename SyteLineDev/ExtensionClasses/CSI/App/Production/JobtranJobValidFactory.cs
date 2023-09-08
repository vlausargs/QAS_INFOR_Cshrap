//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranJobValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobtranJobValidFactory
	{
		public IJobtranJobValid Create(IApplicationDB appDB)
		{
			var _JobtranJobValid = new Production.JobtranJobValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranJobValidExt = timerfactory.Create<Production.IJobtranJobValid>(_JobtranJobValid);
			
			return iJobtranJobValidExt;
		}
	}
}
