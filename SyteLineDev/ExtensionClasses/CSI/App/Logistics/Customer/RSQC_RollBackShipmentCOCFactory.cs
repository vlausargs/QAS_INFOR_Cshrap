//PROJECT NAME: Logistics
//CLASS NAME: RSQC_RollBackShipmentCOCFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RSQC_RollBackShipmentCOCFactory
	{
		public IRSQC_RollBackShipmentCOC Create(IApplicationDB appDB)
		{
			var _RSQC_RollBackShipmentCOC = new Logistics.Customer.RSQC_RollBackShipmentCOC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_RollBackShipmentCOCExt = timerfactory.Create<Logistics.Customer.IRSQC_RollBackShipmentCOC>(_RSQC_RollBackShipmentCOC);
			
			return iRSQC_RollBackShipmentCOCExt;
		}
	}
}
