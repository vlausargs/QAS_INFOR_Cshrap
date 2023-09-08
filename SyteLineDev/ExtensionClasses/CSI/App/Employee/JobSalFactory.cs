//PROJECT NAME: CSIEmployee
//CLASS NAME: JobSalFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class JobSalFactory
    {
        public IJobSal Create(IApplicationDB appDB)
        {
            var _JobSal = new JobSal(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobSalExt = timerfactory.Create<IJobSal>(_JobSal);

            return iJobSalExt;
        }
    }
}
