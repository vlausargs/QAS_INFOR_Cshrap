//PROJECT NAME: CSICustomer
//CLASS NAME: ARPayPostDeleteTmpFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ARPayPostDeleteTmpFactory
    {
        public IARPayPostDeleteTmp Create(IApplicationDB appDB)
        {
            var _ARPayPostDeleteTmp = new ARPayPostDeleteTmp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iARPayPostDeleteTmpExt = timerfactory.Create<IARPayPostDeleteTmp>(_ARPayPostDeleteTmp);

            return iARPayPostDeleteTmpExt;
        }
    }
}
