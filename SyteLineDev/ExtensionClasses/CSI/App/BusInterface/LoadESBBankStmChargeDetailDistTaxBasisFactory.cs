//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetailDistTaxBasisFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmChargeDetailDistTaxBasisFactory
	{
		public ILoadESBBankStmChargeDetailDistTaxBasis Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmChargeDetailDistTaxBasis = new BusInterface.LoadESBBankStmChargeDetailDistTaxBasis(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmChargeDetailDistTaxBasisExt = timerfactory.Create<BusInterface.ILoadESBBankStmChargeDetailDistTaxBasis>(_LoadESBBankStmChargeDetailDistTaxBasis);
			
			return iLoadESBBankStmChargeDetailDistTaxBasisExt;
		}
	}
}
