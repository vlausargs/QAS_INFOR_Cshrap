//PROJECT NAME: CSIEmployee
//CLASS NAME: PayrollParamUpdatePrtrxFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PayrollParamUpdatePrtrxFactory
    {
        public IPayrollParamUpdatePrtrx Create(IApplicationDB appDB)
        {
            var _PayrollParamUpdatePrtrx = new PayrollParamUpdatePrtrx(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPayrollParamUpdatePrtrxExt = timerfactory.Create<IPayrollParamUpdatePrtrx>(_PayrollParamUpdatePrtrx);

            return iPayrollParamUpdatePrtrxExt;
        }
    }
}
