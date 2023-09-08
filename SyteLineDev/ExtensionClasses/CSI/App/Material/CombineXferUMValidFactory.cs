//PROJECT NAME: CSIMaterial
//CLASS NAME: CombineXferUMValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CombineXferUMValidFactory
    {
        public ICombineXferUMValid Create(IApplicationDB appDB)
        {
            var _CombineXferUMValid = new CombineXferUMValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCombineXferUMValidExt = timerfactory.Create<ICombineXferUMValid>(_CombineXferUMValid);

            return iCombineXferUMValidExt;
        }
    }
}
