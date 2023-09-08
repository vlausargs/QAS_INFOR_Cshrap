//PROJECT NAME: Production
//CLASS NAME: WBSPopulateProjWbsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class WBSPopulateProjWbsFactory
	{
		public IWBSPopulateProjWbs Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _WBSPopulateProjWbs = new Production.Projects.WBSPopulateProjWbs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWBSPopulateProjWbsExt = timerfactory.Create<Production.Projects.IWBSPopulateProjWbs>(_WBSPopulateProjWbs);
			
			return iWBSPopulateProjWbsExt;
		}
	}
}
