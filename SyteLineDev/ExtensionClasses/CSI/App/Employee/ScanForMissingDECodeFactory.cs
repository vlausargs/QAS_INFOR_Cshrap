//PROJECT NAME: CSIEmployee
//CLASS NAME: ScanForMissingDECodeFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class ScanForMissingDECodeFactory
    {
        public IScanForMissingDECode Create(IApplicationDB appDB)
        {
            var _ScanForMissingDECode = new ScanForMissingDECode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iScanForMissingDECodeExt = timerfactory.Create<IScanForMissingDECode>(_ScanForMissingDECode);

            return iScanForMissingDECodeExt;
        }
    }
}
