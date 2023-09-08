//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpReviewDateGetFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpReviewDateGetFactory
    {
        public IEmpReviewDateGet Create(IApplicationDB appDB)
        {
            var _EmpReviewDateGet = new EmpReviewDateGet(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpReviewDateGetExt = timerfactory.Create<IEmpReviewDateGet>(_EmpReviewDateGet);

            return iEmpReviewDateGetExt;
        }
    }
}
