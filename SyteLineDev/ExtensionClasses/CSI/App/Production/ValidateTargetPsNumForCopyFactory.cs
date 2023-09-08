//PROJECT NAME: CSIProduct
//CLASS NAME: ValidateTargetPsNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class ValidateTargetPsNumForCopyFactory
    {
        public IValidateTargetPsNumForCopy Create(IApplicationDB appDB)
        {
            var _ValidateTargetPsNumForCopy = new ValidateTargetPsNumForCopy(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateTargetPsNumForCopyExt = timerfactory.Create<IValidateTargetPsNumForCopy>(_ValidateTargetPsNumForCopy);

            return iValidateTargetPsNumForCopyExt;
        }
    }
}
