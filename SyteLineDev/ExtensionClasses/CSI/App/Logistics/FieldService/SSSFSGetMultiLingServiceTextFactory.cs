//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetMultiLingServiceTextFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSGetMultiLingServiceTextFactory
    {
        public ISSSFSGetMultiLingServiceText Create(IApplicationDB appDB)
        {
            var _SSSFSGetMultiLingServiceText = new SSSFSGetMultiLingServiceText(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSGetMultiLingServiceTextExt = timerfactory.Create<ISSSFSGetMultiLingServiceText>(_SSSFSGetMultiLingServiceText);

            return iSSSFSGetMultiLingServiceTextExt;
        }
    }
}

