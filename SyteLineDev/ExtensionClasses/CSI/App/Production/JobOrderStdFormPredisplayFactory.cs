//PROJECT NAME: CSIProduct
//CLASS NAME: JobOrderStdFormPredisplayFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobOrderStdFormPredisplayFactory
	{
		public IJobOrderStdFormPredisplay Create(IApplicationDB appDB)
		{
			var _JobOrderStdFormPredisplay = new Production.JobOrderStdFormPredisplay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobOrderStdFormPredisplayExt = timerfactory.Create<Production.IJobOrderStdFormPredisplay>(_JobOrderStdFormPredisplay);
			
			return iJobOrderStdFormPredisplayExt;
		}
	}
}
