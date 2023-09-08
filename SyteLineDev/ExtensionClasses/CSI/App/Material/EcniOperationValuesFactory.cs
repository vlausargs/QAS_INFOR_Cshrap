//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniOperationValuesFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniOperationValuesFactory
    {
        public IEcniOperationValues Create(IApplicationDB appDB)
        {
            var _EcniOperationValues = new EcniOperationValues(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniOperationValuesExt = timerfactory.Create<IEcniOperationValues>(_EcniOperationValues);

            return iEcniOperationValuesExt;
        }
    }
}
