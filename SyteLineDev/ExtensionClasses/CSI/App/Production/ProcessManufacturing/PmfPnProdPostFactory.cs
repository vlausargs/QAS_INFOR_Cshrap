//PROJECT NAME: Production
//CLASS NAME: PmfPnProdPostFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnProdPostFactory
	{
		public IPmfPnProdPost Create(IApplicationDB appDB)
		{
			var _PmfPnProdPost = new Production.ProcessManufacturing.PmfPnProdPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnProdPostExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnProdPost>(_PmfPnProdPost);
			
			return iPmfPnProdPostExt;
		}
	}
}
