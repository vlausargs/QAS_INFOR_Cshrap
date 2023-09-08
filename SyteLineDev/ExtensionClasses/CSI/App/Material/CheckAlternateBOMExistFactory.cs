//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckAlternateBOMExistFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CheckAlternateBOMExistFactory
    {
        public ICheckAlternateBOMExist Create(IApplicationDB appDB)
        {
            var _CheckAlternateBOMExist = new CheckAlternateBOMExist(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckAlternateBOMExistExt = timerfactory.Create<ICheckAlternateBOMExist>(_CheckAlternateBOMExist);

            return iCheckAlternateBOMExistExt;
        }
    }
}
