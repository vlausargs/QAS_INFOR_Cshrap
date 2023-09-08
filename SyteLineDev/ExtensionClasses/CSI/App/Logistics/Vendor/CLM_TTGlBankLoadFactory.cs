//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_TTGlBankLoadFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_TTGlBankLoadFactory
	{
		public ICLM_TTGlBankLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_TTGlBankLoad = new Logistics.Vendor.CLM_TTGlBankLoad(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TTGlBankLoadExt = timerfactory.Create<Logistics.Vendor.ICLM_TTGlBankLoad>(_CLM_TTGlBankLoad);
			
			return iCLM_TTGlBankLoadExt;
		}
	}
}
