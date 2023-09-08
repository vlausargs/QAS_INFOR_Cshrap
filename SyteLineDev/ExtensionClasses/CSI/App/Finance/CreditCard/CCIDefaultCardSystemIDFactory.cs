//PROJECT NAME: CSICCI
//CLASS NAME: CCIDefaultCardSystemIDFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class CCIDefaultCardSystemIDFactory
	{
		public ICCIDefaultCardSystemID Create(IApplicationDB appDB)
		{
			var _CCIDefaultCardSystemID = new Finance.CreditCard.CCIDefaultCardSystemID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCCIDefaultCardSystemIDExt = timerfactory.Create<Finance.CreditCard.ICCIDefaultCardSystemID>(_CCIDefaultCardSystemID);
			
			return iCCIDefaultCardSystemIDExt;
		}
	}
}
