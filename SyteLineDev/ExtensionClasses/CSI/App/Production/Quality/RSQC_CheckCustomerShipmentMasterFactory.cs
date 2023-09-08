//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckCustomerShipmentMasterFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckCustomerShipmentMasterFactory
	{
		public IRSQC_CheckCustomerShipmentMaster Create(IApplicationDB appDB)
		{
			var _RSQC_CheckCustomerShipmentMaster = new Production.Quality.RSQC_CheckCustomerShipmentMaster(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckCustomerShipmentMasterExt = timerfactory.Create<Production.Quality.IRSQC_CheckCustomerShipmentMaster>(_RSQC_CheckCustomerShipmentMaster);
			
			return iRSQC_CheckCustomerShipmentMasterExt;
		}
	}
}
