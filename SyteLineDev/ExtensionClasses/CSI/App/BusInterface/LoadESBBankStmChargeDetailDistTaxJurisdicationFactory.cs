//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetailDistTaxJurisdicationFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmChargeDetailDistTaxJurisdicationFactory
	{
		public ILoadESBBankStmChargeDetailDistTaxJurisdication Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmChargeDetailDistTaxJurisdication = new BusInterface.LoadESBBankStmChargeDetailDistTaxJurisdication(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmChargeDetailDistTaxJurisdicationExt = timerfactory.Create<BusInterface.ILoadESBBankStmChargeDetailDistTaxJurisdication>(_LoadESBBankStmChargeDetailDistTaxJurisdication);
			
			return iLoadESBBankStmChargeDetailDistTaxJurisdicationExt;
		}
	}
}
