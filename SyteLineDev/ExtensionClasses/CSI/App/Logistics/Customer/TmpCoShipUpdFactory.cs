//PROJECT NAME: Logistics
//CLASS NAME: TmpCoShipUpdFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TmpCoShipUpdFactory
	{
		public ITmpCoShipUpd Create(IApplicationDB appDB)
		{
			var _TmpCoShipUpd = new Logistics.Customer.TmpCoShipUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTmpCoShipUpdExt = timerfactory.Create<Logistics.Customer.ITmpCoShipUpd>(_TmpCoShipUpd);
			
			return iTmpCoShipUpdExt;
		}
	}
}
