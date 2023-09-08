//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckCustomerFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckCustomerFactory
	{
		public IRSQC_CheckCustomer Create(IApplicationDB appDB)
		{
			var _RSQC_CheckCustomer = new Production.Quality.RSQC_CheckCustomer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckCustomerExt = timerfactory.Create<Production.Quality.IRSQC_CheckCustomer>(_RSQC_CheckCustomer);
			
			return iRSQC_CheckCustomerExt;
		}
	}
}
