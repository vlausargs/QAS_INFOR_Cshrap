//PROJECT NAME: CSICustomer
//CLASS NAME: ReadyQtyCalcFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ReadyQtyCalcFactory
    {
        public IReadyQtyCalc Create(IApplicationDB appDB)
        {
            var _ReadyQtyCalc = new ReadyQtyCalc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iReadyQtyCalcExt = timerfactory.Create<IReadyQtyCalc>(_ReadyQtyCalc);

            return iReadyQtyCalcExt;
        }
    }
}
