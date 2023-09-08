//PROJECT NAME: Logistics
//CLASS NAME: AptrxgFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AptrxgFactory
	{
		public IAptrxg Create(IApplicationDB appDB)
		{
			var _Aptrxg = new Logistics.Vendor.Aptrxg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAptrxgExt = timerfactory.Create<Logistics.Vendor.IAptrxg>(_Aptrxg);
			
			return iAptrxgExt;
		}
	}
}
