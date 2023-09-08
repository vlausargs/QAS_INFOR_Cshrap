//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckTaxCodeFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class CheckTaxCodeFactory
    {
        public ICheckTaxCode Create(IApplicationDB appDB)
        {
            var _CheckTaxCode = new CheckTaxCode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckTaxCodeExt = timerfactory.Create<ICheckTaxCode>(_CheckTaxCode);

            return iCheckTaxCodeExt;
        }
    }
}
