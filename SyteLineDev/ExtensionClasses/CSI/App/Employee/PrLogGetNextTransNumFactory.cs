//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogGetNextTransNumFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrLogGetNextTransNumFactory
    {
        public IPrLogGetNextTransNum Create(IApplicationDB appDB)
        {
            var _PrLogGetNextTransNum = new PrLogGetNextTransNum(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrLogGetNextTransNumExt = timerfactory.Create<IPrLogGetNextTransNum>(_PrLogGetNextTransNum);

            return iPrLogGetNextTransNumExt;
        }
    }
}
