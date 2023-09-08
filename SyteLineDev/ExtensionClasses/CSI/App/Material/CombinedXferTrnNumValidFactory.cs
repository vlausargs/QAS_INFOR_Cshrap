//PROJECT NAME: CSIMaterial
//CLASS NAME: CombinedXferTrnNumValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CombinedXferTrnNumValidFactory
    {
        public ICombinedXferTrnNumValid Create(IApplicationDB appDB)
        {
            var _CombinedXferTrnNumValid = new CombinedXferTrnNumValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCombinedXferTrnNumValidExt = timerfactory.Create<ICombinedXferTrnNumValid>(_CombinedXferTrnNumValid);

            return iCombinedXferTrnNumValidExt;
        }
    }
}
