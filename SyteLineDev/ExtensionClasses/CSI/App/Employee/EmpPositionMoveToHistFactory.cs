//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionMoveToHistFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpPositionMoveToHistFactory
    {
        public IEmpPositionMoveToHist Create(IApplicationDB appDB)
        {
            var _EmpPositionMoveToHist = new EmpPositionMoveToHist(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpPositionMoveToHistExt = timerfactory.Create<IEmpPositionMoveToHist>(_EmpPositionMoveToHist);

            return iEmpPositionMoveToHistExt;
        }
    }
}
