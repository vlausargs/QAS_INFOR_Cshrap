//PROJECT NAME: CSIEmployee
//CLASS NAME: GenerateEmploymentPeriodsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class GenerateEmploymentPeriodsFactory
    {
        public IGenerateEmploymentPeriods Create(IApplicationDB appDB)
        {
            var _GenerateEmploymentPeriods = new GenerateEmploymentPeriods(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGenerateEmploymentPeriodsExt = timerfactory.Create<IGenerateEmploymentPeriods>(_GenerateEmploymentPeriods);

            return iGenerateEmploymentPeriodsExt;
        }
    }
}
