//PROJECT NAME: CSIMaterial
//CLASS NAME: CpTrFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CpTrFactory
    {
        public ICpTr Create(IApplicationDB appDB)
        {
            var _CpTr = new CpTr(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCpTrExt = timerfactory.Create<ICpTr>(_CpTr);

            return iCpTrExt;
        }
    }
}
