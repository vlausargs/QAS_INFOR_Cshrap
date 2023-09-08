//PROJECT NAME: CSIProduct
//CLASS NAME: BOMBulkImport_ExcludeListFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class BOMBulkImport_ExcludeListFactory
    {
        public IBOMBulkImport_ExcludeList Create(IApplicationDB appDB)
        {
            var _BOMBulkImport_ExcludeList = new BOMBulkImport_ExcludeList(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iBOMBulkImport_ExcludeListExt = timerfactory.Create<IBOMBulkImport_ExcludeList>(_BOMBulkImport_ExcludeList);

            return iBOMBulkImport_ExcludeListExt;
        }
    }
}
