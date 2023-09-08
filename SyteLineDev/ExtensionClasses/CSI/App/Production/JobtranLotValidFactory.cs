//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranLotValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobtranLotValidFactory
	{
		public IJobtranLotValid Create(IApplicationDB appDB)
		{
			var _JobtranLotValid = new Production.JobtranLotValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranLotValidExt = timerfactory.Create<Production.IJobtranLotValid>(_JobtranLotValid);
			
			return iJobtranLotValidExt;
		}
	}
}
