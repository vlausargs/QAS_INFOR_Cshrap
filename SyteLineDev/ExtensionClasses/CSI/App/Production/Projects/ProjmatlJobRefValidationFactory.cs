//PROJECT NAME: CSIProjects
//CLASS NAME: ProjmatlJobRefValidationFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjmatlJobRefValidationFactory
	{
		public IProjmatlJobRefValidation Create(IApplicationDB appDB)
		{
			var _ProjmatlJobRefValidation = new Production.Projects.ProjmatlJobRefValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjmatlJobRefValidationExt = timerfactory.Create<Production.Projects.IProjmatlJobRefValidation>(_ProjmatlJobRefValidation);
			
			return iProjmatlJobRefValidationExt;
		}
	}
}
