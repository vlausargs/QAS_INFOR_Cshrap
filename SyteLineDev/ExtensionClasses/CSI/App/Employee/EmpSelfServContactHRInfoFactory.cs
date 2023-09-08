//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpSelfServContactHRInfoFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpSelfServContactHRInfoFactory
    {
        public IEmpSelfServContactHRInfo Create(IApplicationDB appDB)
        {
            var _EmpSelfServContactHRInfo = new EmpSelfServContactHRInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpSelfServContactHRInfoExt = timerfactory.Create<IEmpSelfServContactHRInfo>(_EmpSelfServContactHRInfo);

            return iEmpSelfServContactHRInfoExt;
        }
    }
}
