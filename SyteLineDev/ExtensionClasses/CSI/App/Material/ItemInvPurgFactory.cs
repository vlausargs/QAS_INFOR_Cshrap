//PROJECT NAME: Material
//CLASS NAME: ItemInvPurgFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
    public class ItemInvPurgFactory
    {
        public IItemInvPurg Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _ItemInvPurg = new Material.ItemInvPurg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemInvPurgExt = timerfactory.Create<Material.IItemInvPurg>(_ItemInvPurg);

            return iItemInvPurgExt;
        }
    }
}
