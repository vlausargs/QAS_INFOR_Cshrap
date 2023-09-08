//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomCheckSubJobFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomCheckSubJobFactory
	{
		public ICopyBomCheckSubJob Create(IApplicationDB appDB)
		{
			var _CopyBomCheckSubJob = new Production.CopyBomCheckSubJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomCheckSubJobExt = timerfactory.Create<Production.ICopyBomCheckSubJob>(_CopyBomCheckSubJob);
			
			return iCopyBomCheckSubJobExt;
		}
	}
}
