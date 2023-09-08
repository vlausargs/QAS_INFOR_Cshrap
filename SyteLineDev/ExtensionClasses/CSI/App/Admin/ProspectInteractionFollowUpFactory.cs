//PROJECT NAME: Admin
//CLASS NAME: ProspectInteractionFollowUpFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class ProspectInteractionFollowUpFactory
	{
		public IProspectInteractionFollowUp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProspectInteractionFollowUp = new Admin.ProspectInteractionFollowUp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProspectInteractionFollowUpExt = timerfactory.Create<Admin.IProspectInteractionFollowUp>(_ProspectInteractionFollowUp);
			
			return iProspectInteractionFollowUpExt;
		}
	}
}
