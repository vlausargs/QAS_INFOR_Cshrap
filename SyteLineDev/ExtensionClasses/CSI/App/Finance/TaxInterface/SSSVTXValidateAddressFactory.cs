//PROJECT NAME: Finance
//CLASS NAME: SSSVTXValidateAddressFactory.cs

using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXValidateAddressFactory
	{
		public ISSSVTXValidateAddress Create(IApplicationDB appDB)
		{
			var _SSSVTXValidateAddress = new Finance.TaxInterface.SSSVTXValidateAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSVTXValidateAddressExt = timerfactory.Create<Finance.TaxInterface.ISSSVTXValidateAddress>(_SSSVTXValidateAddress);
			
			return iSSSVTXValidateAddressExt;
		}
	}
}
