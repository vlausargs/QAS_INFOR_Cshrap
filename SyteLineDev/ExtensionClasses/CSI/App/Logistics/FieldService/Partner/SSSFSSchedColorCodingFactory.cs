//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedColorCodingFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public class SSSFSSchedColorCodingFactory
    {
        public ISSSFSSchedColorCoding Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSFSSchedColorCoding = new SSSFSSchedColorCoding(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSchedColorCodingExt = timerfactory.Create<ISSSFSSchedColorCoding>(_SSSFSSchedColorCoding);

            return iSSSFSSchedColorCodingExt;
        }
    }
}
