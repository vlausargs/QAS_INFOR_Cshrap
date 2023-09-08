//PROJECT NAME: CSIEmployee
//CLASS NAME: DepPrintDoProcessFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class DepPrintDoProcessFactory
    {
        public IDepPrintDoProcess Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _DepPrintDoProcess = new DepPrintDoProcess(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDepPrintDoProcessExt = timerfactory.Create<IDepPrintDoProcess>(_DepPrintDoProcess);

            return iDepPrintDoProcessExt;
        }
    }
}
