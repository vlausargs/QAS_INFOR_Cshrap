//PROJECT NAME: CSIProduct
//CLASS NAME: ProcessJobMatlTransFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ProcessJobMatlTransFactory
	{
		public IProcessJobMatlTrans Create(IApplicationDB appDB)
		{
			var _ProcessJobMatlTrans = new Production.ProcessJobMatlTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessJobMatlTransExt = timerfactory.Create<Production.IProcessJobMatlTrans>(_ProcessJobMatlTrans);
			
			return iProcessJobMatlTransExt;
		}
	}
}
