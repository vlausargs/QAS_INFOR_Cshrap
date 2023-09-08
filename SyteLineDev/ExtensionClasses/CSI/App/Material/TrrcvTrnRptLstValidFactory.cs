//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvTrnRptLstValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrrcvTrnRptLstValidFactory
    {
        public ITrrcvTrnRptLstValid Create(IApplicationDB appDB)
        {
            var _TrrcvTrnRptLstValid = new TrrcvTrnRptLstValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrrcvTrnRptLstValidExt = timerfactory.Create<ITrrcvTrnRptLstValid>(_TrrcvTrnRptLstValid);

            return iTrrcvTrnRptLstValidExt;
        }
    }
}
