//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetSerialInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSGetSerialInfoFactory
    {
        public ISSSFSGetSerialInfo Create(IApplicationDB appDB)
        {
            var _SSSFSGetSerialInfo = new SSSFSGetSerialInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSGetSerialInfoExt = timerfactory.Create<ISSSFSGetSerialInfo>(_SSSFSGetSerialInfo);

            return iSSSFSGetSerialInfoExt;
        }
    }
}

