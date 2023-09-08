//PROJECT NAME: CSIFinance
//CLASS NAME: PRGetNextCheckNumberFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class PRGetNextCheckNumberFactory
    {
        public IPRGetNextCheckNumber Create(IApplicationDB appDB)
        {
            var _PRGetNextCheckNumber = new PRGetNextCheckNumber(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLGlbanksExt = timerfactory.Create<IPRGetNextCheckNumber>(_PRGetNextCheckNumber);

            return iSLGlbanksExt;
        }
    }
}