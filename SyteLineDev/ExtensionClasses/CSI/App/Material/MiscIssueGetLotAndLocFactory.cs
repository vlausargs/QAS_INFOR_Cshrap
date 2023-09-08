//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLotAndLocFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class MiscIssueGetLotAndLocFactory
    {
        public IMiscIssueGetLotAndLoc Create(IApplicationDB appDB)
        {
            var _MiscIssueGetLotAndLoc = new MiscIssueGetLotAndLoc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMiscIssueGetLotAndLocExt = timerfactory.Create<IMiscIssueGetLotAndLoc>(_MiscIssueGetLotAndLoc);

            return iMiscIssueGetLotAndLocExt;
        }
    }
}
