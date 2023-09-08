//PROJECT NAME: CSIEmployee
//CLASS NAME: DepPrintInitFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class DepPrintInitFactory
    {
        public IDepPrintInit Create(IApplicationDB appDB)
        {
            var _DepPrintInit = new DepPrintInit(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDepPrintInitExt = timerfactory.Create<IDepPrintInit>(_DepPrintInit);

            return iDepPrintInitExt;
        }
    }
}
