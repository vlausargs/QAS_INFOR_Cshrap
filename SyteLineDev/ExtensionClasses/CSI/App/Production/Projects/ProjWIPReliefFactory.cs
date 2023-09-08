//PROJECT NAME: CSIProjects
//CLASS NAME: ProjWIPReliefFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProjWIPReliefFactory
	{
		public IProjWIPRelief Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProjWIPRelief = new Production.Projects.ProjWIPRelief(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjWIPReliefExt = timerfactory.Create<Production.Projects.IProjWIPRelief>(_ProjWIPRelief);
			
			return iProjWIPReliefExt;
		}
	}
}
