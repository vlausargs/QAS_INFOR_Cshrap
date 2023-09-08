//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniMaterialValuesFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniMaterialValuesFactory
    {
        public IEcniMaterialValues Create(IApplicationDB appDB)
        {
            var _EcniMaterialValues = new EcniMaterialValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniMaterialValuesExt = timerfactory.Create<IEcniMaterialValues>(_EcniMaterialValues);

            return iEcniMaterialValuesExt;
        }
    }
}
