//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmTranCodeFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmTranCodeFactory
	{
		public ILoadESBBankStmTranCode Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmTranCode = new BusInterface.LoadESBBankStmTranCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmTranCodeExt = timerfactory.Create<BusInterface.ILoadESBBankStmTranCode>(_LoadESBBankStmTranCode);
			
			return iLoadESBBankStmTranCodeExt;
		}
	}
}
