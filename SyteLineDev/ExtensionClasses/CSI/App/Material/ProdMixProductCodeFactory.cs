//PROJECT NAME: CSIMaterial
//CLASS NAME: ProdMixProductCodeFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ProdMixProductCodeFactory
    {
        public IProdMixProductCode Create(IApplicationDB appDB)
        {
            var _ProdMixProductCode = new ProdMixProductCode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iProdMixProductCodeExt = timerfactory.Create<IProdMixProductCode>(_ProdMixProductCode);

            return iProdMixProductCodeExt;
        }
    }
}
