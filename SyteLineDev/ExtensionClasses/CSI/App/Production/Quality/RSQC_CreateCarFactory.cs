//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateCarFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateCarFactory
	{
		public IRSQC_CreateCar Create(IApplicationDB appDB)
		{
			var _RSQC_CreateCar = new Production.Quality.RSQC_CreateCar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateCarExt = timerfactory.Create<Production.Quality.IRSQC_CreateCar>(_RSQC_CreateCar);
			
			return iRSQC_CreateCarExt;
		}
	}
}
