//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnitemQtyReqValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrnitemQtyReqValidFactory
    {
        public ITrnitemQtyReqValid Create(IApplicationDB appDB)
        {
            var _TrnitemQtyReqValid = new TrnitemQtyReqValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrnitemQtyReqValidExt = timerfactory.Create<ITrnitemQtyReqValid>(_TrnitemQtyReqValid);

            return iTrnitemQtyReqValidExt;
        }
    }
}
