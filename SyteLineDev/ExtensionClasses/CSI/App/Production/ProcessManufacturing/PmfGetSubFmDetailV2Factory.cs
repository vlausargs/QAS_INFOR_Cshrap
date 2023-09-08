//PROJECT NAME: Production
//CLASS NAME: PmfGetSubFmDetailV2Factory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetSubFmDetailV2Factory
	{
		public IPmfGetSubFmDetailV2 Create(IApplicationDB appDB)
		{
			var _PmfGetSubFmDetailV2 = new Production.ProcessManufacturing.PmfGetSubFmDetailV2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfGetSubFmDetailV2Ext = timerfactory.Create<Production.ProcessManufacturing.IPmfGetSubFmDetailV2>(_PmfGetSubFmDetailV2);
			
			return iPmfGetSubFmDetailV2Ext;
		}
	}
}
