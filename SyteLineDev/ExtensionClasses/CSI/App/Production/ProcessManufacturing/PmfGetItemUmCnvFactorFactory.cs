//PROJECT NAME: Production
//CLASS NAME: PmfGetItemUmCnvFactFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetItemUmCnvFactFactory
	{
		public IPmfGetItemUmCnvFact Create(IApplicationDB appDB)
		{
			var _PmfGetItemUmCnvFact = new Production.ProcessManufacturing.PmfGetItemUmCnvFact(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfGetItemUmCnvFactExt = timerfactory.Create<Production.ProcessManufacturing.IPmfGetItemUmCnvFact>(_PmfGetItemUmCnvFact);
			
			return iPmfGetItemUmCnvFactExt;
		}
	}
}
