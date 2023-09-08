//PROJECT NAME: Reporting
//CLASS NAME: SSSFSSRORpt_MatlRequirementFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSSRORpt_MatlRequirementFactory
	{
		public ISSSFSSRORpt_MatlRequirement Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSRORpt_MatlRequirement = new Reporting.SSSFSSRORpt_MatlRequirement(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSRORpt_MatlRequirementExt = timerfactory.Create<Reporting.ISSSFSSRORpt_MatlRequirement>(_SSSFSSRORpt_MatlRequirement);
			
			return iSSSFSSRORpt_MatlRequirementExt;
		}
	}
}
