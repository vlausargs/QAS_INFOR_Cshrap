//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSGetUnitItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSGetUnitItemFactory
    {
        public ISSSFSGetUnitItem Create(IApplicationDB appDB)
        {
            var _SSSFSGetUnitItem = new SSSFSGetUnitItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSGetUnitItemExt = timerfactory.Create<ISSSFSGetUnitItem>(_SSSFSGetUnitItem);

            return iSSSFSGetUnitItemExt;
        }
    }
}
