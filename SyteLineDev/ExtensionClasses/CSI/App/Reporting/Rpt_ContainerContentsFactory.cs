//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ContainerContentsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ContainerContentsFactory
	{
		public IRpt_ContainerContents Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ContainerContents = new Reporting.Rpt_ContainerContents(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ContainerContentsExt = timerfactory.Create<Reporting.IRpt_ContainerContents>(_Rpt_ContainerContents);
			
			return iRpt_ContainerContentsExt;
		}
	}
}
