//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_RevMsNomFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class CLM_RevMsNomFactory
	{
		public ICLM_RevMsNom Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_RevMsNom = new Production.Projects.CLM_RevMsNom(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_RevMsNomExt = timerfactory.Create<Production.Projects.ICLM_RevMsNom>(_CLM_RevMsNom);
			
			return iCLM_RevMsNomExt;
		}
	}
}
