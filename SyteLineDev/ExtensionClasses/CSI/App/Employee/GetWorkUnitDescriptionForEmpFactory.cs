//PROJECT NAME: CSIEmployee
//CLASS NAME: GetWorkUnitDescriptionForEmpFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class GetWorkUnitDescriptionForEmpFactory
    {
        public IGetWorkUnitDescriptionForEmp Create(IApplicationDB appDB)
        {
            var _GetWorkUnitDescriptionForEmp = new GetWorkUnitDescriptionForEmp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetWorkUnitDescriptionForEmpExt = timerfactory.Create<IGetWorkUnitDescriptionForEmp>(_GetWorkUnitDescriptionForEmp);

            return iGetWorkUnitDescriptionForEmpExt;
        }
    }
}
