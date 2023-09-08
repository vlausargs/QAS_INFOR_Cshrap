//PROJECT NAME: CSIProduct
//CLASS NAME: GetJobParmsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class GetJobParmsFactory
	{
		public IGetJobParms Create(IApplicationDB appDB)
		{
			var _GetJobParms = new Production.GetJobParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetJobParmsExt = timerfactory.Create<Production.IGetJobParms>(_GetJobParms);
			
			return iGetJobParmsExt;
		}
	}
}
