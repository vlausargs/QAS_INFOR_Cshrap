//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckW2TaxConsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class CheckW2TaxConsFactory
    {
        public ICheckW2TaxCons Create(IApplicationDB appDB)
        {
            var _CheckW2TaxCons = new CheckW2TaxCons(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckW2TaxConsExt = timerfactory.Create<ICheckW2TaxCons>(_CheckW2TaxCons);

            return iCheckW2TaxConsExt;
        }
    }
}
