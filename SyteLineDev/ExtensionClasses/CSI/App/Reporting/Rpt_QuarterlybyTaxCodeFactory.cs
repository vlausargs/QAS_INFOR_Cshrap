//PROJECT NAME: Reporting
//CLASS NAME: Rpt_QuarterlybyTaxCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_QuarterlybyTaxCodeFactory
	{
		public IRpt_QuarterlybyTaxCode Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_QuarterlybyTaxCode = new Reporting.Rpt_QuarterlybyTaxCode(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_QuarterlybyTaxCodeExt = timerfactory.Create<Reporting.IRpt_QuarterlybyTaxCode>(_Rpt_QuarterlybyTaxCode);
			
			return iRpt_QuarterlybyTaxCodeExt;
		}
	}
}
