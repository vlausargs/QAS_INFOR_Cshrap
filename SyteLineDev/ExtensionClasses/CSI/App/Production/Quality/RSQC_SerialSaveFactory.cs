//PROJECT NAME: Production
//CLASS NAME: RSQC_SerialSaveFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SerialSaveFactory
	{
		public IRSQC_SerialSave Create(IApplicationDB appDB)
		{
			var _RSQC_SerialSave = new Production.Quality.RSQC_SerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SerialSaveExt = timerfactory.Create<Production.Quality.IRSQC_SerialSave>(_RSQC_SerialSave);
			
			return iRSQC_SerialSaveExt;
		}
	}
}
