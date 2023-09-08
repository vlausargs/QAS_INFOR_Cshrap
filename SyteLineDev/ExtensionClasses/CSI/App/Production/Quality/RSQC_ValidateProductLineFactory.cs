//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateProductLiFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateProductLiFactory
	{
		public IRSQC_ValidateProductLi Create(IApplicationDB appDB)
		{
			var _RSQC_ValidateProductLi = new Production.Quality.RSQC_ValidateProductLi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ValidateProductLiExt = timerfactory.Create<Production.Quality.IRSQC_ValidateProductLi>(_RSQC_ValidateProductLi);
			
			return iRSQC_ValidateProductLiExt;
		}
	}
}
