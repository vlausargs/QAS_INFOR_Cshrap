//PROJECT NAME: CSIProduct
//CLASS NAME: GetProdMixFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class GetProdMixFactory
	{
		public IGetProdMix Create(IApplicationDB appDB)
		{
			var _GetProdMix = new Production.GetProdMix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProdMixExt = timerfactory.Create<Production.IGetProdMix>(_GetProdMix);
			
			return iGetProdMixExt;
		}
	}
}
