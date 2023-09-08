//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmPostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmPostFactory
	{
		public ILoadESBBankStmPost Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmPost = new BusInterface.LoadESBBankStmPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmPostExt = timerfactory.Create<BusInterface.ILoadESBBankStmPost>(_LoadESBBankStmPost);
			
			return iLoadESBBankStmPostExt;
		}
	}
}
