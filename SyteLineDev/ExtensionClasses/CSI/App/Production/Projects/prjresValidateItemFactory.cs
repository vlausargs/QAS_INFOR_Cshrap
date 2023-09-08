//PROJECT NAME: CSIProjects
//CLASS NAME: prjresValidateItemFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class prjresValidateItemFactory
	{
		public IprjresValidateItem Create(IApplicationDB appDB)
		{
			var _prjresValidateItem = new Production.Projects.prjresValidateItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iprjresValidateItemExt = timerfactory.Create<Production.Projects.IprjresValidateItem>(_prjresValidateItem);
			
			return iprjresValidateItemExt;
		}
	}
}
