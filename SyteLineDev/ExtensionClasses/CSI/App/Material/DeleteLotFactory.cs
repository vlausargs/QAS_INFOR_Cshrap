//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteLotFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class DeleteLotFactory
    {
        public IDeleteLot Create(IApplicationDB appDB)
        {
            var _DeleteLot = new DeleteLot(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDeleteLotExt = timerfactory.Create<IDeleteLot>(_DeleteLot);

            return iDeleteLotExt;
        }
    }
}
