//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemFeatureGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemFeatureGroupFactory
	{
		public IRpt_ItemFeatureGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemFeatureGroup = new Reporting.Rpt_ItemFeatureGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemFeatureGroupExt = timerfactory.Create<Reporting.IRpt_ItemFeatureGroup>(_Rpt_ItemFeatureGroup);
			
			return iRpt_ItemFeatureGroupExt;
		}
	}
}
