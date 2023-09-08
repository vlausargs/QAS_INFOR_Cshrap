//PROJECT NAME: CSIMaterial
//CLASS NAME: RSQC_ShipUpdateCOC2Factory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RSQC_ShipUpdateCOC2Factory
    {
        public IRSQC_ShipUpdateCOC2 Create(IApplicationDB appDB)
        {
            var _RSQC_ShipUpdateCOC2 = new RSQC_ShipUpdateCOC2(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_ShipUpdateCOC2Ext = timerfactory.Create<IRSQC_ShipUpdateCOC2>(_RSQC_ShipUpdateCOC2);

            return iRSQC_ShipUpdateCOC2Ext;
        }
    }
}
