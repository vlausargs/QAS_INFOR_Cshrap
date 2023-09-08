//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSWarrEndFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSWarrEndFactory
    {
        public ISSSFSWarrEnd Create(IApplicationDB appDB)
        {
            var _SSSFSWarrEnd = new Logistics.FieldService.SSSFSWarrEnd(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSWarrEndExt = timerfactory.Create<Logistics.FieldService.ISSSFSWarrEnd>(_SSSFSWarrEnd);

            return iSSSFSWarrEndExt;
        }
    }
}
