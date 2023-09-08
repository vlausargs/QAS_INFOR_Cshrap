//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogUpdateOrAddDeleteCheckFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrLogUpdateOrAddDeleteCheckFactory
    {
        public IPrLogUpdateOrAddDeleteCheck Create(IApplicationDB appDB)
        {
            var _PrLogUpdateOrAddDeleteCheck = new PrLogUpdateOrAddDeleteCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrLogUpdateOrAddDeleteCheckExt = timerfactory.Create<IPrLogUpdateOrAddDeleteCheck>(_PrLogUpdateOrAddDeleteCheck);

            return iPrLogUpdateOrAddDeleteCheckExt;
        }
    }
}
