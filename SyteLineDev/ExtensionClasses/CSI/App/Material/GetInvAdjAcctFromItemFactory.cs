//PROJECT NAME: CSIMaterial
//CLASS NAME: GetInvAdjAcctFromItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetInvAdjAcctFromItemFactory
    {
        public IGetInvAdjAcctFromItem Create(IApplicationDB appDB)
        {
            var _GetInvAdjAcctFromItem = new GetInvAdjAcctFromItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetInvAdjAcctFromItemExt = timerfactory.Create<IGetInvAdjAcctFromItem>(_GetInvAdjAcctFromItem);

            return iGetInvAdjAcctFromItemExt;
        }
    }
}
