//PROJECT NAME: CSIProduct
//CLASS NAME: GetMaterialSequenFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class GetMaterialSequenFactory
	{
		public IGetMaterialSequen Create(IApplicationDB appDB)
		{
			var _GetMaterialSequen = new Production.GetMaterialSequen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMaterialSequenExt = timerfactory.Create<Production.IGetMaterialSequen>(_GetMaterialSequen);
			
			return iGetMaterialSequenExt;
		}
	}
}
