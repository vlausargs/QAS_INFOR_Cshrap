//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDepositInitFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSDepositInitFactory
    {
        public ISSSFSDepositInit Create(IApplicationDB appDB)
        {
            var _SSSFSDepositInit = new SSSFSDepositInit(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSDepositInitExt = timerfactory.Create<ISSSFSDepositInit>(_SSSFSDepositInit);

            return iSSSFSDepositInitExt;
        }
    }
}
