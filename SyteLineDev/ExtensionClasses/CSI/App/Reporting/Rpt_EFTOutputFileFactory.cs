//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EFTOutputFileFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EFTOutputFileFactory
	{
		public IRpt_EFTOutputFile Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EFTOutputFile = new Reporting.Rpt_EFTOutputFile(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EFTOutputFileExt = timerfactory.Create<Reporting.IRpt_EFTOutputFile>(_Rpt_EFTOutputFile);
			
			return iRpt_EFTOutputFileExt;
		}
	}
}
