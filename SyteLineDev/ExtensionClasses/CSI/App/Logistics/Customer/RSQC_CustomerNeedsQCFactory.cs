//PROJECT NAME: Logistics
//CLASS NAME: RSQC_CustomerNeedsQCFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RSQC_CustomerNeedsQCFactory
	{
		public IRSQC_CustomerNeedsQC Create(IApplicationDB appDB)
		{
			var _RSQC_CustomerNeedsQC = new Logistics.Customer.RSQC_CustomerNeedsQC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CustomerNeedsQCExt = timerfactory.Create<Logistics.Customer.IRSQC_CustomerNeedsQC>(_RSQC_CustomerNeedsQC);
			
			return iRSQC_CustomerNeedsQCExt;
		}
	}
}
