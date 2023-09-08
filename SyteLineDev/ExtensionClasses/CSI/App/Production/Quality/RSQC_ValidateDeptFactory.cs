//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateDeptFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateDeptFactory
	{
		public IRSQC_ValidateDept Create(IApplicationDB appDB)
		{
			var _RSQC_ValidateDept = new Production.Quality.RSQC_ValidateDept(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ValidateDeptExt = timerfactory.Create<Production.Quality.IRSQC_ValidateDept>(_RSQC_ValidateDept);
			
			return iRSQC_ValidateDeptExt;
		}
	}
}
