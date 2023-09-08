//PROJECT NAME: CSIRSQCS
//CLASS NAME: RSQC_QCCheckFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
    public class RSQC_QCCheckFactory
    {
        public IRSQC_QCCheck Create(IApplicationDB appDB)
        {
            var _RSQC_QCCheck = new Production.Quality.RSQC_QCCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_QCCheckExt = timerfactory.Create<Production.Quality.IRSQC_QCCheck>(_RSQC_QCCheck);

            return iRSQC_QCCheckExt;
        }
    }
}
