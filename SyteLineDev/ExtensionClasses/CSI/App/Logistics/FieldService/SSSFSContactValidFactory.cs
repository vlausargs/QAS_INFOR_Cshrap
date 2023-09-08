//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSContactValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSContactValidFactory
    {
        public ISSSFSContactValid Create(IApplicationDB appDB)
        {
            var _SSSFSContactValid = new SSSFSContactValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSContactValidExt = timerfactory.Create<ISSSFSContactValid>(_SSSFSContactValid);

            return iSSSFSContactValidExt;
        }
    }
}
