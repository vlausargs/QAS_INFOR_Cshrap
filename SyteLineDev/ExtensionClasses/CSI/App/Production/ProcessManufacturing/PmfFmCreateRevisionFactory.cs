//PROJECT NAME: Production
//CLASS NAME: PmfFmCreateRevisionFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmCreateRevisionFactory
	{
		public IPmfFmCreateRevision Create(IApplicationDB appDB)
		{
			var _PmfFmCreateRevision = new Production.ProcessManufacturing.PmfFmCreateRevision(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmCreateRevisionExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmCreateRevision>(_PmfFmCreateRevision);
			
			return iPmfFmCreateRevisionExt;
		}
	}
}
