//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSSerialCLFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSSerialCLFactory
    {
        public ISSSPOSSerialCL Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSPOSSerialCL = new POS.SSSPOSSerialCL(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSSerialCLExt = timerfactory.Create<POS.ISSSPOSSerialCL>(_SSSPOSSerialCL);

            return iSSSPOSSerialCLExt;
        }
    }
}
