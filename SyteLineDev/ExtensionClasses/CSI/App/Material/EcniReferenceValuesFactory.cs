//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniReferenceValuesFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniReferenceValuesFactory
    {
        public IEcniReferenceValues Create(IApplicationDB appDB)
        {
            var _EcniReferenceValues = new EcniReferenceValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniReferenceValuesExt = timerfactory.Create<IEcniReferenceValues>(_EcniReferenceValues);

            return iEcniReferenceValuesExt;
        }
    }
}
