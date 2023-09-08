//PROJECT NAME: CSIProduct
//CLASS NAME: CurrentMaterialsItemVFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CurrentMaterialsItemVFactory
	{
		public ICurrentMaterialsItemV Create(IApplicationDB appDB)
		{
			var _CurrentMaterialsItemV = new Production.CurrentMaterialsItemV(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCurrentMaterialsItemVExt = timerfactory.Create<Production.ICurrentMaterialsItemV>(_CurrentMaterialsItemV);
			
			return iCurrentMaterialsItemVExt;
		}
	}
}
