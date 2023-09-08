//PROJECT NAME: CSIProjects
//CLASS NAME: ValidateTargetProjNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ValidateTargetProjNumForCopyFactory
	{
		public IValidateTargetProjNumForCopy Create(IApplicationDB appDB)
		{
			var _ValidateTargetProjNumForCopy = new Production.Projects.ValidateTargetProjNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateTargetProjNumForCopyExt = timerfactory.Create<Production.Projects.IValidateTargetProjNumForCopy>(_ValidateTargetProjNumForCopy);
			
			return iValidateTargetProjNumForCopyExt;
		}
	}
}
