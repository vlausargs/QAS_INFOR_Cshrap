//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSParmsSyncIncSroFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSParmsSyncIncSroFactory
    {
        public ISSSFSParmsSyncIncSro Create(IApplicationDB appDB)
        {
            var _SSSFSParmsSyncIncSro = new Logistics.FieldService.SSSFSParmsSyncIncSro(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSParmsSyncIncSroExt = timerfactory.Create<Logistics.FieldService.ISSSFSParmsSyncIncSro>(_SSSFSParmsSyncIncSro);

            return iSSSFSParmsSyncIncSroExt;
        }
    }
}
