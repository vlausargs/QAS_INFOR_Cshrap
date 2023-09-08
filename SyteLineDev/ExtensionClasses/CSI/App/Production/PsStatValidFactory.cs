//PROJECT NAME: CSIProduct
//CLASS NAME: PsStatValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class PsStatValidFactory
    {
        public IPsStatValid Create(IApplicationDB appDB)
        {
            var _PsStatValid = new PsStatValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPsStatValidExt = timerfactory.Create<IPsStatValid>(_PsStatValid);

            return iPsStatValidExt;
        }
    }
}
