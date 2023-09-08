//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateCustomFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateCustomFactory
	{
		public IRSQC_ValidateCustom Create(IApplicationDB appDB)
		{
			var _RSQC_ValidateCustom = new Production.Quality.RSQC_ValidateCustom(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ValidateCustomExt = timerfactory.Create<Production.Quality.IRSQC_ValidateCustom>(_RSQC_ValidateCustom);
			
			return iRSQC_ValidateCustomExt;
		}
	}
}
