//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSReverseLookUpCLFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSReverseLookUpCLFactory
    {
        public ISSSPOSReverseLookUpCL Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSPOSReverseLookUpCL = new POS.SSSPOSReverseLookUpCL(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSReverseLookUpCLExt = timerfactory.Create<POS.ISSSPOSReverseLookUpCL>(_SSSPOSReverseLookUpCL);

            return iSSSPOSReverseLookUpCLExt;
        }
    }
}
