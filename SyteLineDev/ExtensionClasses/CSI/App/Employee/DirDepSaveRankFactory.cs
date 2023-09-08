//PROJECT NAME: CSIEmployee
//CLASS NAME: DirDepSaveRankFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class DirDepSaveRankFactory
    {
        public IDirDepSaveRank Create(IApplicationDB appDB)
        {
            var _DirDepSaveRank = new DirDepSaveRank(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDirDepSaveRankExt = timerfactory.Create<IDirDepSaveRank>(_DirDepSaveRank);

            return iDirDepSaveRankExt;
        }
    }
}
