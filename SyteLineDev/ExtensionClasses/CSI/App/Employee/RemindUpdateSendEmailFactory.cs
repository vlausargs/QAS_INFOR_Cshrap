//PROJECT NAME: CSIEmployee
//CLASS NAME: RemindUpdateSendEmailFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class RemindUpdateSendEmailFactory
    {
        public IRemindUpdateSendEmail Create(IApplicationDB appDB)
        {
            var _RemindUpdateSendEmail = new RemindUpdateSendEmail(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRemindUpdateSendEmailExt = timerfactory.Create<IRemindUpdateSendEmail>(_RemindUpdateSendEmail);

            return iRemindUpdateSendEmailExt;
        }
    }
}
