//PROJECT NAME: CSIMaterial
//CLASS NAME: UpdateFeatRankFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class UpdateFeatRankFactory
    {
        public IUpdateFeatRank Create(IApplicationDB appDB)
        {
            var _UpdateFeatRank = new UpdateFeatRank(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iUpdateFeatRankExt = timerfactory.Create<IUpdateFeatRank>(_UpdateFeatRank);

            return iUpdateFeatRankExt;
        }
    }
}
