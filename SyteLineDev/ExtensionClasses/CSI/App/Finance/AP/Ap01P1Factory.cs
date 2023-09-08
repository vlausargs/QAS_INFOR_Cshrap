//PROJECT NAME: CSIFinance
//CLASS NAME: Ap01P1Factory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class Ap01P1Factory
    {
        public IAp01P1 Create(IApplicationDB appDB)
        {
            var _Ap01P1 = new Ap01P1(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLBankHdrsExt = timerfactory.Create<IAp01P1>(_Ap01P1);

            return iSLBankHdrsExt;
        }
    }
}
