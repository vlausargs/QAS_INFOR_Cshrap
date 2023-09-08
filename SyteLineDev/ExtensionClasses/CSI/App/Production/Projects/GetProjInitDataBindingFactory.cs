//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjInitDataBindingFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetProjInitDataBindingFactory
	{
		public IGetProjInitDataBinding Create(IApplicationDB appDB)
		{
			var _GetProjInitDataBinding = new Production.Projects.GetProjInitDataBinding(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjInitDataBindingExt = timerfactory.Create<Production.Projects.IGetProjInitDataBinding>(_GetProjInitDataBinding);
			
			return iGetProjInitDataBindingExt;
		}
	}
}
