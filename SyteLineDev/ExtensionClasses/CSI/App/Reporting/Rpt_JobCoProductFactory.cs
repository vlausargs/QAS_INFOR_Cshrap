//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCoProductFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobCoProductFactory
	{
		public IRpt_JobCoProduct Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobCoProduct = new Reporting.Rpt_JobCoProduct(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobCoProductExt = timerfactory.Create<Reporting.IRpt_JobCoProduct>(_Rpt_JobCoProduct);
			
			return iRpt_JobCoProductExt;
		}
	}
}
