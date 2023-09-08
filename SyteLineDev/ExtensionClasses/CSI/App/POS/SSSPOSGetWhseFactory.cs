//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSGetWhseFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSGetWhseFactory
    {
        public ISSSPOSGetWhse Create(IApplicationDB appDB)
        {
            var _SSSPOSGetWhse = new POS.SSSPOSGetWhse(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSGetWhseExt = timerfactory.Create<POS.ISSSPOSGetWhse>(_SSSPOSGetWhse);

            return iSSSPOSGetWhseExt;
        }
    }
}
