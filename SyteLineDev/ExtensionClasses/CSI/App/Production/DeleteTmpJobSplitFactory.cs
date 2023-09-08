//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteTmpJobSplitFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class DeleteTmpJobSplitFactory
    {
        public IDeleteTmpJobSplit Create(IApplicationDB appDB)
        {
            var _DeleteTmpJobSplit = new DeleteTmpJobSplit(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDeleteTmpJobSplitExt = timerfactory.Create<IDeleteTmpJobSplit>(_DeleteTmpJobSplit);

            return iDeleteTmpJobSplitExt;
        }
    }
}
