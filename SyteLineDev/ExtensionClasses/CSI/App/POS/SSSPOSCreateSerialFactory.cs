//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSCreateSerialFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSCreateSerialFactory
    {
        public ISSSPOSCreateSerial Create(IApplicationDB appDB)
        {
            var _SSSPOSCreateSerial = new POS.SSSPOSCreateSerial(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSCreateSerialExt = timerfactory.Create<POS.ISSSPOSCreateSerial>(_SSSPOSCreateSerial);

            return iSSSPOSCreateSerialExt;
        }
    }
}
