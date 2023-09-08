//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniConvCostFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniConvCostFactory
    {
        public IEcniConvCost Create(IApplicationDB appDB)
        {
            var _EcniConvCost = new EcniConvCost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniConvCostExt = timerfactory.Create<IEcniConvCost>(_EcniConvCost);

            return iEcniConvCostExt;
        }
    }
}
