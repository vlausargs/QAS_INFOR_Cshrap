//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefCustomerDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefCustomerDataFactory
	{
		public IRSQC_GetXrefCustomerData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefCustomerData = new Production.Quality.RSQC_GetXrefCustomerData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefCustomerDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefCustomerData>(_RSQC_GetXrefCustomerData);
			
			return iRSQC_GetXrefCustomerDataExt;
		}
	}
}
