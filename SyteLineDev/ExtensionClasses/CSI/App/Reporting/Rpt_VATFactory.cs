//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VATFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VATFactory
	{
		public IRpt_VAT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VAT = new Reporting.Rpt_VAT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VATExt = timerfactory.Create<Reporting.IRpt_VAT>(_Rpt_VAT);
			
			return iRpt_VATExt;
		}
	}
}
