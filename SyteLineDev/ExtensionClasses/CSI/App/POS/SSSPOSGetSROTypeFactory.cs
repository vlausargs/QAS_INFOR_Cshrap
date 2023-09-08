//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSGetSROTypeFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSGetSROTypeFactory
    {
        public ISSSPOSGetSROType Create(IApplicationDB appDB)
        {
            var _SSSPOSGetSROType = new POS.SSSPOSGetSROType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSGetSROTypeExt = timerfactory.Create<POS.ISSSPOSGetSROType>(_SSSPOSGetSROType);

            return iSSSPOSGetSROTypeExt;
        }
    }
}
