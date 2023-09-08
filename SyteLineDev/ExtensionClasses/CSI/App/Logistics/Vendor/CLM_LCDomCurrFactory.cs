//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_LCDomCurrFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_LCDomCurrFactory
	{
		public ICLM_LCDomCurr Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LCDomCurr = new Logistics.Vendor.CLM_LCDomCurr(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LCDomCurrExt = timerfactory.Create<Logistics.Vendor.ICLM_LCDomCurr>(_CLM_LCDomCurr);
			
			return iCLM_LCDomCurrExt;
		}
	}
}
