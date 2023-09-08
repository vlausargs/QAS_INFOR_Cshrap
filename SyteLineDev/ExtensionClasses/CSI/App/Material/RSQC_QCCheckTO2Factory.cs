//PROJECT NAME: CSIMaterial
//CLASS NAME: RSQC_QCCheckTO2Factory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RSQC_QCCheckTO2Factory
    {
        public IRSQC_QCCheckTO2 Create(IApplicationDB appDB)
        {
            var _RSQC_QCCheckTO2 = new RSQC_QCCheckTO2(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_QCCheckTO2Ext = timerfactory.Create<IRSQC_QCCheckTO2>(_RSQC_QCCheckTO2);

            return iRSQC_QCCheckTO2Ext;
        }
    }
}
