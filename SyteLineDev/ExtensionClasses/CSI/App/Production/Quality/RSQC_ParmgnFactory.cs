//PROJECT NAME: Production
//CLASS NAME: RSQC_ParmgnFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ParmgnFactory
	{
		public IRSQC_Parmgn Create(IApplicationDB appDB)
		{
			var _RSQC_Parmgn = new Production.Quality.RSQC_Parmgn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ParmgnExt = timerfactory.Create<Production.Quality.IRSQC_Parmgn>(_RSQC_Parmgn);
			
			return iRSQC_ParmgnExt;
		}
	}
}
