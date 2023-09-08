//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSMultiSiteSroCopyFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSMultiSiteSroCopyFactory
    {
        public ISSSFSMultiSiteSroCopy Create(IApplicationDB appDB)
        {
            var _SSSFSMultiSiteSroCopy = new SSSFSMultiSiteSroCopy(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSMultiSiteSroCopyExt = timerfactory.Create<ISSSFSMultiSiteSroCopy>(_SSSFSMultiSiteSroCopy);

            return iSSSFSMultiSiteSroCopyExt;
        }
    }
}
