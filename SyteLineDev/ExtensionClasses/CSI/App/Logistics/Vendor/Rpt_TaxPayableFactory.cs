//PROJECT NAME: Logistics
//CLASS NAME: Rpt_TaxPayableFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class Rpt_TaxPayableFactory
	{
		public IRpt_TaxPayable Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TaxPayable = new Logistics.Vendor.Rpt_TaxPayable(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TaxPayableExt = timerfactory.Create<Logistics.Vendor.IRpt_TaxPayable>(_Rpt_TaxPayable);
			
			return iRpt_TaxPayableExt;
		}
	}
}
