//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateTargetTrnNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ValidateTargetTrnNumForCopyFactory
    {
        public IValidateTargetTrnNumForCopy Create(IApplicationDB appDB)
        {
            var _ValidateTargetTrnNumForCopy = new ValidateTargetTrnNumForCopy(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateTargetTrnNumForCopyExt = timerfactory.Create<IValidateTargetTrnNumForCopy>(_ValidateTargetTrnNumForCopy);

            return iValidateTargetTrnNumForCopyExt;
        }
    }
}
