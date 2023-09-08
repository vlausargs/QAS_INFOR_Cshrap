//PROJECT NAME: CSIProjects
//CLASS NAME: PmatlValidateMatlQtyFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class PmatlValidateMatlQtyFactory
	{
		public IPmatlValidateMatlQty Create(IApplicationDB appDB)
		{
			var _PmatlValidateMatlQty = new Production.Projects.PmatlValidateMatlQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmatlValidateMatlQtyExt = timerfactory.Create<Production.Projects.IPmatlValidateMatlQty>(_PmatlValidateMatlQty);
			
			return iPmatlValidateMatlQtyExt;
		}
	}
}
