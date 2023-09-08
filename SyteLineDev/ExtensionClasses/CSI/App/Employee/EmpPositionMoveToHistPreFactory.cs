//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionMoveToHistPreFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpPositionMoveToHistPreFactory
    {
        public IEmpPositionMoveToHistPre Create(IApplicationDB appDB)
        {
            var _EmpPositionMoveToHistPre = new EmpPositionMoveToHistPre(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpPositionMoveToHistPreExt = timerfactory.Create<IEmpPositionMoveToHistPre>(_EmpPositionMoveToHistPre);

            return iEmpPositionMoveToHistPreExt;
        }
    }
}
