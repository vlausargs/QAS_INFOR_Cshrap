//PROJECT NAME: CSIProjects
//CLASS NAME: ProjLabrVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjLabrVerifyCloseFormFactory
	{
		public IProjLabrVerifyCloseForm Create(IApplicationDB appDB)
		{
			var _ProjLabrVerifyCloseForm = new Production.Projects.ProjLabrVerifyCloseForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjLabrVerifyCloseFormExt = timerfactory.Create<Production.Projects.IProjLabrVerifyCloseForm>(_ProjLabrVerifyCloseForm);
			
			return iProjLabrVerifyCloseFormExt;
		}
	}
}
