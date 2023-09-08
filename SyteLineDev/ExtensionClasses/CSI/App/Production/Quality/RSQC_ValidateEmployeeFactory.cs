//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateEmployFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateEmployFactory
	{
		public IRSQC_ValidateEmploy Create(IApplicationDB appDB)
		{
			var _RSQC_ValidateEmploy = new Production.Quality.RSQC_ValidateEmploy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ValidateEmployExt = timerfactory.Create<Production.Quality.IRSQC_ValidateEmploy>(_RSQC_ValidateEmploy);
			
			return iRSQC_ValidateEmployExt;
		}
	}
}
