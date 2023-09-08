//PROJECT NAME: CSIEmployee
//CLASS NAME: ValidateDirDepAccountFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class ValidateDirDepAccountFactory
    {
        public IValidateDirDepAccount Create(IApplicationDB appDB)
        {
            var _ValidateDirDepAccount = new ValidateDirDepAccount(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateDirDepAccountExt = timerfactory.Create<IValidateDirDepAccount>(_ValidateDirDepAccount);

            return iValidateDirDepAccountExt;
        }
    }
}
