//PROJECT NAME: CSIEmployee
//CLASS NAME: ValidateEmployeeUsernameFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class ValidateEmployeeUsernameFactory
    {
        public IValidateEmployeeUsername Create(IApplicationDB appDB)
        {
            var _ValidateEmployeeUsername = new ValidateEmployeeUsername(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateEmployeeUsernameExt = timerfactory.Create<IValidateEmployeeUsername>(_ValidateEmployeeUsername);

            return iValidateEmployeeUsernameExt;
        }
    }
}
