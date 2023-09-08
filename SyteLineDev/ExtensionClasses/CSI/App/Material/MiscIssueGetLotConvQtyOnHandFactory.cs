//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLotConvQtyOnHandFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class MiscIssueGetLotConvQtyOnHandFactory
    {
        public IMiscIssueGetLotConvQtyOnHand Create(IApplicationDB appDB)
        {
            var _MiscIssueGetLotConvQtyOnHand = new MiscIssueGetLotConvQtyOnHand(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMiscIssueGetLotConvQtyOnHandExt = timerfactory.Create<IMiscIssueGetLotConvQtyOnHand>(_MiscIssueGetLotConvQtyOnHand);

            return iMiscIssueGetLotConvQtyOnHandExt;
        }
    }
}
