//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetDefConfigUpdMethodFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSGetDefConfigUpdMethodFactory
    {
        public ISSSFSGetDefConfigUpdMethod Create(IApplicationDB appDB)
        {
            var _SSSFSGetDefConfigUpdMethod = new SSSFSGetDefConfigUpdMethod(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSGetDefConfigUpdMethodExt = timerfactory.Create<ISSSFSGetDefConfigUpdMethod>(_SSSFSGetDefConfigUpdMethod);

            return iSSSFSGetDefConfigUpdMethodExt;
        }
    }
}

