//PROJECT NAME: CSIEmployee
//CLASS NAME: RemindAssigneeSendEmailFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class RemindAssigneeSendEmailFactory
    {
        public IRemindAssigneeSendEmail Create(IApplicationDB appDB)
        {
            var _RemindAssigneeSendEmail = new RemindAssigneeSendEmail(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRemindAssigneeSendEmailExt = timerfactory.Create<IRemindAssigneeSendEmail>(_RemindAssigneeSendEmail);

            return iRemindAssigneeSendEmailExt;
        }
    }
}
