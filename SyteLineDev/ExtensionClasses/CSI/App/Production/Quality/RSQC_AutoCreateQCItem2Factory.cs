//PROJECT NAME: CSIRSQCS
//CLASS NAME: RSQC_AutoCreateQCItem2Factory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
    public class RSQC_AutoCreateQCItem2Factory
    {
        public IRSQC_AutoCreateQCItem2 Create(IApplicationDB appDB)
        {
            var _RSQC_AutoCreateQCItem2 = new Production.Quality.RSQC_AutoCreateQCItem2(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_AutoCreateQCItem2Ext = timerfactory.Create<Production.Quality.IRSQC_AutoCreateQCItem2>(_RSQC_AutoCreateQCItem2);

            return iRSQC_AutoCreateQCItem2Ext;
        }
    }
}
