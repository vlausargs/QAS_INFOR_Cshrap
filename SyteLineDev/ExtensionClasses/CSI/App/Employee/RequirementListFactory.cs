//PROJECT NAME: CSIEmployee
//CLASS NAME: RequirementListFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class RequirementListFactory
    {
        public IRequirementList Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _RequirementList = new RequirementList(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRequirementListExt = timerfactory.Create<IRequirementList>(_RequirementList);

            return iRequirementListExt;
        }
    }
}
