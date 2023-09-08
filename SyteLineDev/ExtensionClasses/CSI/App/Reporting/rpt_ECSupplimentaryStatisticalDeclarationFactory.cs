//PROJECT NAME: Reporting
//CLASS NAME: rpt_ECSupplimentaryStatisticalDeclarationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class rpt_ECSupplimentaryStatisticalDeclarationFactory
	{
		public Irpt_ECSupplimentaryStatisticalDeclaration Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _rpt_ECSupplimentaryStatisticalDeclaration = new Reporting.rpt_ECSupplimentaryStatisticalDeclaration(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var irpt_ECSupplimentaryStatisticalDeclarationExt = timerfactory.Create<Reporting.Irpt_ECSupplimentaryStatisticalDeclaration>(_rpt_ECSupplimentaryStatisticalDeclaration);
			
			return irpt_ECSupplimentaryStatisticalDeclarationExt;
		}
	}
}
