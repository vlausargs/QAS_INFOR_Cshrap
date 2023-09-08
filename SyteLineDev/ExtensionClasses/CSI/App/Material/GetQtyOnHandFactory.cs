//PROJECT NAME: CSIMaterial
//CLASS NAME: GetQtyOnHandFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetQtyOnHandFactory
    {
        public IGetQtyOnHand Create(IApplicationDB appDB)
        {
            var _GetQtyOnHand = new GetQtyOnHand(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetQtyOnHandExt = timerfactory.Create<IGetQtyOnHand>(_GetQtyOnHand);

            return iGetQtyOnHandExt;
        }
    }
}
