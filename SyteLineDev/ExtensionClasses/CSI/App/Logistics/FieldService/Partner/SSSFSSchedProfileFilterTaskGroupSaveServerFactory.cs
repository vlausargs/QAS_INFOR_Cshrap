//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedProfileFilterTaskGroupSaveServerFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public class SSSFSSchedProfileFilterTaskGroupSaveServerFactory
    {
        public ISSSFSSchedProfileFilterTaskGroupSaveServer Create(IApplicationDB appDB)
        {
            var _SSSFSSchedProfileFilterTaskGroupSaveServer = new SSSFSSchedProfileFilterTaskGroupSaveServer(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSchedProfileFilterTaskGroupSaveServerExt = timerfactory.Create<ISSSFSSchedProfileFilterTaskGroupSaveServer>(_SSSFSSchedProfileFilterTaskGroupSaveServer);

            return iSSSFSSchedProfileFilterTaskGroupSaveServerExt;
        }
    }
}
