//PROJECT NAME: CSIMaterial
//CLASS NAME: RSQC_CheckVendorFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RSQC_CheckVendorFactory
    {
        public IRSQC_CheckVendor Create(IApplicationDB appDB)
        {
            var _RSQC_CheckVendor = new RSQC_CheckVendor(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_CheckVendorExt = timerfactory.Create<IRSQC_CheckVendor>(_RSQC_CheckVendor);

            return iRSQC_CheckVendorExt;
        }
    }
}
