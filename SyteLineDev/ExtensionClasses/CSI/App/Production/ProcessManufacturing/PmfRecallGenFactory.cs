//PROJECT NAME: CSIPmf
//CLASS NAME: PmfRecallGenFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRecallGenFactory
	{
		public IPmfRecallGen Create(IApplicationDB appDB)
		{
			var _PmfRecallGen = new Production.ProcessManufacturing.PmfRecallGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRecallGenExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRecallGen>(_PmfRecallGen);
			
			return iPmfRecallGenExt;
		}
	}
}
