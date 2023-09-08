//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetailDistTaxFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmChargeDetailDistTaxFactory
	{
		public ILoadESBBankStmChargeDetailDistTax Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmChargeDetailDistTax = new BusInterface.LoadESBBankStmChargeDetailDistTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmChargeDetailDistTaxExt = timerfactory.Create<BusInterface.ILoadESBBankStmChargeDetailDistTax>(_LoadESBBankStmChargeDetailDistTax);
			
			return iLoadESBBankStmChargeDetailDistTaxExt;
		}
	}
}
