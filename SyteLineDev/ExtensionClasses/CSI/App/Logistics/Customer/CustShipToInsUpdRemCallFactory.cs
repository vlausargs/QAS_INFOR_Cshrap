//PROJECT NAME: Logistics
//CLASS NAME: CustShipToInsUpdRemCallFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustShipToInsUpdRemCallFactory
	{
		public ICustShipToInsUpdRemCall Create(IApplicationDB appDB)
		{
			var _CustShipToInsUpdRemCall = new Logistics.Customer.CustShipToInsUpdRemCall(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustShipToInsUpdRemCallExt = timerfactory.Create<Logistics.Customer.ICustShipToInsUpdRemCall>(_CustShipToInsUpdRemCall);
			
			return iCustShipToInsUpdRemCallExt;
		}
	}
}
