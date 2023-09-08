//PROJECT NAME: CSIFinance
//CLASS NAME: VerifyFaClassDeptFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class VerifyFaClassDeptFactory
    {
        public IVerifyFaClassDept Create(IApplicationDB appDB)
        {
            var _VerifyFaClassDept = new VerifyFaClassDept(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFamastersExt = timerfactory.Create<IVerifyFaClassDept>(_VerifyFaClassDept);

            return iSLFamastersExt;
        }
    }
}
