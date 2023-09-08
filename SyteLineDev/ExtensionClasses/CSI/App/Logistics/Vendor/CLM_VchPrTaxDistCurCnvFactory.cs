//PROJECT NAME: Logistics
//CLASS NAME: CLM_VchPrTaxDistCurCnvFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_VchPrTaxDistCurCnvFactory
	{
		public ICLM_VchPrTaxDistCurCnv Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_VchPrTaxDistCurCnv = new Logistics.Vendor.CLM_VchPrTaxDistCurCnv(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_VchPrTaxDistCurCnvExt = timerfactory.Create<Logistics.Vendor.ICLM_VchPrTaxDistCurCnv>(_CLM_VchPrTaxDistCurCnv);
			
			return iCLM_VchPrTaxDistCurCnvExt;
		}
	}
}
